using System;
using System.Runtime.InteropServices;

namespace FreeRdp.NativeStructs
{
    [StructLayout(LayoutKind.Explicit, Pack = 8)]
    public unsafe struct rdpContext
    {
        [FieldOffset(0)] public freerdp* instance;
        [FieldOffset(1 * 8)] public IntPtr peer;
        [FieldOffset(2 * 8)] public fixed UInt32 paddingA[16 - 2];

        [FieldOffset(16 * 8)] public int argc;
        [FieldOffset(17 * 8)] public IntPtr argv;
        [FieldOffset(18 * 8)] public IntPtr pubSub;
        [FieldOffset(19 * 8)] public fixed UInt32 paddingB[32 - 19];

        [FieldOffset(32 * 8)] public IntPtr rdp;
        [FieldOffset(33 * 8)] public IntPtr gdi;
        [FieldOffset(34 * 8)] public IntPtr rail;
        [FieldOffset(35 * 8)] public IntPtr cache;
        [FieldOffset(36 * 8)] public IntPtr channels;
        [FieldOffset(37 * 8)] public IntPtr graphics;
        [FieldOffset(38 * 8)] public IntPtr input;
        [FieldOffset(39 * 8)] public IntPtr update;
        [FieldOffset(40 * 8)] public rdpSettings* settings;
        [FieldOffset(41 * 8)] public fixed UInt32 paddingC[64 - 41];

        [FieldOffset(64 * 8)] public fixed UInt32 paddingD[96 - 64];
        [FieldOffset(96 * 8)] public fixed UInt32 paddingE[128 - 96];
    };
}
