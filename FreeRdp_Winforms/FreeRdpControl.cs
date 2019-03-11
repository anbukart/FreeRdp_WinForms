using FreeRdp.NativeStructs;
using FreeRDP.FreeRDPNativeApi;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FreeRdp_Winforms
{
    public unsafe partial class FreeRdpControl : Form
    {
        private rdpContext* _context;
        private rdp_client_entry_points_v1* _entryPoint;
        private rdpSettings* _settings;
        private freerdp* _instance;

        public string Hostname;
        public string Domain;
        public string Username;
        public string Password;

        public FreeRdpControl()
        {
            InitializeComponent();

            rdp_client_entry_points_v1 e = new rdp_client_entry_points_v1();
            _entryPoint = &e;

            NativeMethods.RdpClientEntry(_entryPoint);

            _context = NativeMethods.freerdp_client_context_new(_entryPoint);

            _instance = _context->instance;
            _settings = _instance->settings;

            // TODO: Set values for Hostname, domain, username, password
            this.Hostname = "10.x.x.xx"; // atleast this one should be set
        }

        public void Connect()
        {
            _settings->ServerPort = 3389;
            _settings->IgnoreCertificate = 1;

            _settings->ServerHostname = Marshal.StringToHGlobalAnsi(Hostname);
            _settings->Username = Marshal.StringToHGlobalAnsi(Username);
            _settings->Domain = Marshal.StringToHGlobalAnsi(Domain);
            _settings->Password = Marshal.StringToHGlobalAnsi(Password);

            _settings->ParentWindowId = (ulong)this.panelFreeRdpContainer.Handle.ToInt64();
            _settings->DesktopHeight = (uint)this.panelFreeRdpContainer.Height;
            _settings->DesktopWidth = (uint)this.panelFreeRdpContainer.Width;

            NativeMethods.freerdp_client_start(_context);
        }

        public void Disconnect()
        {
            NativeMethods.freerdp_client_stop(_context);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Connect();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Disconnect();
        }
    }
}
