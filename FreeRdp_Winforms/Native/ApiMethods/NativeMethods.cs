using FreeRdp.NativeStructs;
using System.Runtime.InteropServices;

namespace FreeRDP.FreeRDPNativeApi
{
    public static unsafe class NativeMethods
    {
        [DllImport("wfreerdp", CallingConvention = CallingConvention.Cdecl)]
        public static extern int RdpClientEntry(rdp_client_entry_points_v1* pEntryPoints);

        [DllImport("freerdp-client2", CallingConvention = CallingConvention.Cdecl)]
        public static extern rdpContext* freerdp_client_context_new(rdp_client_entry_points_v1* pEntryPoints);

        [DllImport("freerdp-client2", CallingConvention = CallingConvention.Cdecl)]
        public static extern int freerdp_client_start(rdpContext* context);

        [DllImport("freerdp-client2", CallingConvention = CallingConvention.Cdecl)]
        public static extern int freerdp_client_stop(rdpContext* context);
    }
}
