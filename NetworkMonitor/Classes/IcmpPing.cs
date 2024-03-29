﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace NetworkMonitor.Classes
{
    public class IcmpPing 
    {
        // Send ping request to specified IP address through the specified IP, using the settings specified.
        public static PingReply Send(IPAddress srcAddress, IPAddress destAddress, int timeout = 5000, byte[] buffer = null, PingOptions po = null)
        {
            if (destAddress == null || destAddress.AddressFamily != AddressFamily.InterNetwork || destAddress.Equals(IPAddress.Any))
                throw new ArgumentException();

            //Defining pinvoke args
            var source = srcAddress == null ? 0 : BitConverter.ToUInt32(srcAddress.GetAddressBytes(), 0);
            var destination = BitConverter.ToUInt32(destAddress.GetAddressBytes(), 0);
            var sendbuffer = buffer ?? new byte[] { };
            var options = new Interop.Option
            {
                Ttl = (po == null ? (byte)255 : (byte)po.Ttl),
                Flags = (po == null ? (byte)0 : po.DontFragment ? (byte)0x02 : (byte)0) //0x02
            };
            var fullReplyBufferSize = Interop.ReplyMarshalLength + sendbuffer.Length; //Size of Reply struct and the transmitted buffer length.



            var allocSpace = Marshal.AllocHGlobal(fullReplyBufferSize); // unmanaged allocation of reply size. TODO Maybe should be allocated on stack
            try
            {
                DateTime start = DateTime.Now;
                var nativeCode = Interop.IcmpSendEcho2Ex(
                    Interop.IcmpHandle, //_In_      HANDLE IcmpHandle,
                    default(IntPtr), //_In_opt_  HANDLE Event,
                    default(IntPtr), //_In_opt_  PIO_APC_ROUTINE ApcRoutine,
                    default(IntPtr), //_In_opt_  PVOID ApcContext
                    source, //_In_      IPAddr SourceAddress,
                    destination, //_In_      IPAddr DestinationAddress,
                    sendbuffer, //_In_      LPVOID RequestData,
                    (short)sendbuffer.Length, //_In_      WORD RequestSize,
                    ref options, //_In_opt_  PIP_OPTION_INFORMATION RequestOptions,
                    allocSpace, //_Out_     LPVOID ReplyBuffer,
                    fullReplyBufferSize, //_In_      DWORD ReplySize,
                    timeout //_In_      DWORD Timeout
                    );
                TimeSpan duration = DateTime.Now - start;
                var reply = (Interop.Reply)Marshal.PtrToStructure(allocSpace, typeof(Interop.Reply)); // Parse the beginning of reply memory to reply struct

                byte[] replyBuffer = null;
                if (sendbuffer.Length != 0)
                {
                    replyBuffer = new byte[sendbuffer.Length];
                    Marshal.Copy(allocSpace + Interop.ReplyMarshalLength, replyBuffer, 0, sendbuffer.Length); //copy the rest of the reply memory to managed byte[]
                }

                if (nativeCode == 0) //Means that native method is faulted.
                    return new PingReply(nativeCode, reply.Status, new IPAddress(reply.Address), duration);
                else
                    return new PingReply(nativeCode, reply.Status, new IPAddress(reply.Address), reply.RoundTripTime, replyBuffer);
            }
            finally
            {
                Marshal.FreeHGlobal(allocSpace); //free allocated space
            }
        }

        /// <summary>Interoperability Helper
        ///     <see cref="http://msdn.microsoft.com/en-us/library/windows/desktop/bb309069(v=vs.85).aspx" />
        /// </summary>
        private static class Interop
        {
            private static IntPtr? icmpHandle;
            private static int? _replyStructLength;

            /// <summary>Returns the application legal icmp handle. Should be close by IcmpCloseHandle
            ///     <see cref="http://msdn.microsoft.com/en-us/library/windows/desktop/aa366045(v=vs.85).aspx" />
            /// </summary>
            public static IntPtr IcmpHandle
            {
                get
                {
                    if (icmpHandle == null)
                    {
                        icmpHandle = IcmpCreateFile();
                    }

                    return icmpHandle.GetValueOrDefault();
                }
            }

            /// <summary>Returns the the marshaled size of the reply struct.</summary>
            public static int ReplyMarshalLength
            {
                get
                {
                    if (_replyStructLength == null)
                    {
                        _replyStructLength = Marshal.SizeOf(typeof(Reply));
                    }
                    return _replyStructLength.GetValueOrDefault();
                }
            }

            // DLL imports to enable ping calls
            [DllImport("Iphlpapi.dll", SetLastError = true)]
            private static extern IntPtr IcmpCreateFile();
            [DllImport("Iphlpapi.dll", SetLastError = true)]
            private static extern bool IcmpCloseHandle(IntPtr handle);
            [DllImport("Iphlpapi.dll", SetLastError = true)]
            public static extern uint IcmpSendEcho2Ex(IntPtr icmpHandle, IntPtr Event, IntPtr apcroutine, IntPtr apccontext, UInt32 sourceAddress, UInt32 destinationAddress, byte[] requestData, short requestSize, ref Option requestOptions, IntPtr replyBuffer, int replySize, int timeout);

            // Structure for ping options
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public struct Option
            {
                public byte Ttl;
                public readonly byte Tos;
                public byte Flags;
                public readonly byte OptionsSize;
                public readonly IntPtr OptionsData;
            }

            // Reply structure received from ping request
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public struct Reply
            {
                public readonly UInt32 Address;
                public readonly int Status;
                public readonly int RoundTripTime;
                public readonly short DataSize;
                public readonly short Reserved;
                public readonly IntPtr DataPtr;
                public readonly Option Options;
            }
        }
    }
}
