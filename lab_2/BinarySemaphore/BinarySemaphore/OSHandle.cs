using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BinarySemaphore
{
    public class OSHandle : IDisposable
    {
        public IntPtr handle;
        private bool disposed = false;

        public OSHandle (int size)
        {
            handle = Marshal.AllocHGlobal(size);
        }

        ~OSHandle()
        {
            Dispose(false);
        }

        public IntPtr Handle
        {
            get 
            { 
                if (!disposed) return handle;
                else throw new ObjectDisposedException(ToString());
            }
        }

        public void Dispose()
        {
            if (!disposed)
            {
                Dispose(true);
                GC.SuppressFinalize(this);
                disposed = true;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(handle);
            }
        }  
    }
}
