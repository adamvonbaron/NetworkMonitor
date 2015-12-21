using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.ComponentModel;

namespace NetworkMonitor.Classes
{
    [Serializable]
    public class PingReply
    {
        // Member variables
        private readonly byte[] _buffer = null;
        private readonly IPAddress _ipAddress = null;
        private readonly uint _nativeCode = 0;
        private readonly TimeSpan _roundTripTime = TimeSpan.Zero;
        private readonly IPStatus _status = IPStatus.Unknown;
        private Win32Exception _exception;

        // Ping method definitions
        internal PingReply(uint nativeCode, int replystatus, IPAddress ipAddress, TimeSpan duration)
        {
            _nativeCode = nativeCode;
            _ipAddress = ipAddress;
            if (Enum.IsDefined(typeof(IPStatus), replystatus))
                _status = (IPStatus)replystatus;
        }

        internal PingReply(uint nativeCode, int replystatus, IPAddress ipAddress, int roundTripTime, byte[] buffer)
        {
            _nativeCode = nativeCode;
            _ipAddress = ipAddress;
            _roundTripTime = TimeSpan.FromMilliseconds(roundTripTime);
            _buffer = buffer;
            if (Enum.IsDefined(typeof(IPStatus), replystatus))
                _status = (IPStatus)replystatus;
        }

        /// <summary>Native result from <code>IcmpSendEcho2Ex</code>.</summary>
        public uint NativeCode
        {
            get { return _nativeCode; }
        }
        public IPStatus Status
        {
            get { return _status; }
        }
        /// <summary>The source address of the reply.</summary>
        public IPAddress IpAddress
        {
            get { return _ipAddress; }
        }
        public byte[] Buffer
        {
            get { return _buffer; }
        }
        public TimeSpan RoundTripTime
        {
            get { return _roundTripTime; }
        }
        /// <summary>Resolves the <code>Win32Exception</code> from native code</summary>
        public Win32Exception Exception
        {
            get
            {
                if (Status != IPStatus.Success)
                    return _exception ?? (_exception = new Win32Exception((int)NativeCode, Status.ToString()));
                else
                    return null;
            }
        }

        public override string ToString()
        {
            if (Status == IPStatus.Success)
            {
                if (Buffer != null)
                    return Status + " from " + IpAddress + " in " + RoundTripTime + " ms with " + Buffer.Length + " bytes";
                else
                    return Status + " from " + IpAddress + " in " + RoundTripTime + " ms with 0 bytes";
            }
            else if (Status != IPStatus.Unknown)
                return Status + " from " + IpAddress;
            else
                return Exception.Message + " from " + IpAddress;
        }
    }
}
