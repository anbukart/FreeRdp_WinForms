using System;
using System.Runtime.InteropServices;

namespace FreeRdp.NativeStructs
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate bool wf_pre_connect(freerdp* instance);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate bool wf_post_connect(freerdp* instance);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate bool wf_authenticate(freerdp* instance, string username, string password, string domain);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void pContextNew(freerdp* instance, rdpContext* context);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void pContextFree(freerdp* instance, rdpContext* context);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate bool pPreConnect(freerdp* instance);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate bool pPostConnect(freerdp* instance);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate bool pAuthenticate(freerdp* instance, IntPtr username, IntPtr password, IntPtr domain);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate bool pVerifyCertificate(freerdp* instance, IntPtr subject, IntPtr issuer, IntPtr fingerprint);

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct rdp_client_entry_points_v1
    {
        public uint Size;
        public uint Version;
        public rdpSettings* settings;

        public IntPtr GlobalInit;
        public IntPtr GlobalUninit;

        public uint ContextSize;

        public IntPtr ClientNew;
        public IntPtr ClientFree;
        public IntPtr ClientStart;
        public IntPtr ClientStop;
    }

    public unsafe delegate bool pRdpGlobalInit();
    public unsafe delegate void pRdpGlobalUninit();
    public unsafe delegate bool pRdpClientNew(freerdp* instance, rdpContext* context);
    public unsafe delegate void pRdpClientFree(freerdp* instance, rdpContext* context);
    public unsafe delegate int pRdpClientStart(rdpContext* context);
    public unsafe delegate int pRdpClientStop(rdpContext* context);

    [StructLayout(LayoutKind.Explicit, Pack = 8)]
    public unsafe struct freerdp
    {
        [FieldOffset(0)] public rdpContext* context;
        [FieldOffset(1 * 8)] public fixed UInt64 paddingA[16 - 1];

        [FieldOffset(16 * 8)] public IntPtr input;
        [FieldOffset(17 * 8)] public IntPtr update;
        [FieldOffset(18 * 8)] public rdpSettings* settings;
        [FieldOffset(19 * 8)] public fixed UInt64 paddingB[32 - 19];

        [FieldOffset(32 * 8)] public UInt32 ContextSize;
        [FieldOffset(33 * 8)] public IntPtr ContextNew;
        [FieldOffset(34 * 8)] public IntPtr ContextFree;
        [FieldOffset(35 * 8)] public fixed UInt64 paddingC[48 - 35];

        [FieldOffset(48 * 8)] public IntPtr PreConnect;
        [FieldOffset(49 * 8)] public IntPtr PostConnect;
        [FieldOffset(50 * 8)] public IntPtr Authenticate;
        [FieldOffset(51 * 8)] public IntPtr VerifyCertificate;
        [FieldOffset(52 * 8)] public fixed UInt64 paddingD[64 - 52];

        [FieldOffset(64 * 8)] public IntPtr SendChannelData;
        [FieldOffset(65 * 8)] public IntPtr RecvChannelData;
        [FieldOffset(66 * 8)] public fixed UInt64 paddingF[80 - 66];
    };
}
