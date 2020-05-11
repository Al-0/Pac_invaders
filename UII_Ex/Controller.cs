using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX.DirectInput;

namespace UII_Ex
{
    class Controller
    {
        // Initialize DirectInput
        SharpDX.DirectInput.DirectInput directInput = new DirectInput();

        // Find a Joystick Guid
        System.Guid joystickGuid = Guid.Empty;

        // Instantiate the joystick
        SharpDX.DirectInput.Joystick joystick;

        public string key = "";
        public int value = 1000000;

        public Controller()
        {
            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
                joystickGuid = deviceInstance.InstanceGuid;

            // If Gamepad not found, look for a Joystick
            if (joystickGuid == Guid.Empty)
                foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
                    joystickGuid = deviceInstance.InstanceGuid;

            // If Joystick not found, throws an error
            if (joystickGuid == Guid.Empty)
            {
                MessageBox.Show("No joystick/Gamepad found.");
            }
            else
            {
                value = 0;
                joystick = new Joystick(directInput, joystickGuid);
                // Set BufferSize in order to use buffered data.
                joystick.Properties.BufferSize = 128;
                // Acquire the joystick
                joystick.Acquire();
            }
        }

        public void Pull()
        {
            if (value != 1000000)
            {
                // Poll events from joystick
                joystick.Poll();
                var datas = joystick.GetBufferedData();
                foreach (var state in datas)
                {
                    key = Convert.ToString(state.Offset);
                    value = state.Value;
                }
            }
        }
    }
}
