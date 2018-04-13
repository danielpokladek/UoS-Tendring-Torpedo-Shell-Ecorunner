using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phidgets;
using Phidgets.Events;

class Program
{
    // Create a new DigitalOutput (InterfaceKit) channel.
    static InterfaceKit ifKit;

    static void InitPhidgets()
    {
        Console.WriteLine("--- Initializing the program. ---");
        Console.WriteLine("- Initializing the InterfaceKit.");
        Console.WriteLine();

        // Initialize the InterfaceKit object,
        ifKit = new InterfaceKit();

        // Hook the phidget specific event handlers.
        ifKit.Attach += new AttachEventHandler(ifKit_Attach);
        ifKit.Detach += new DetachEventHandler(ifKit_Detach);
        ifKit.Error += new ErrorEventHandler(ifKit_Error);

        // Open the object for device connections.
        Console.WriteLine("- Opening InterfaceKit on device.");

        ifKit.open();

        // Wait for attachement of the interfaceKit
        Console.WriteLine("- Waiting for InterfaceKit to be attached");
        ifKit.waitForAttachment();
    }

    static void Main(string[] args)
    {
        InitPhidgets();

        WaitForUserInput();
    }

    static void WaitForUserInput()
    {
        Console.WriteLine();
        Console.WriteLine("Waiting for input.");
        Console.Write("Toggle digital output: ");
        var input = Console.ReadLine();

        if (input == "0")
        {
            if (ifKit.outputs[0] == true)
            {
                ifKit.outputs[0] = false;
                WaitForUserInput();
            }
            else
            {
                ifKit.outputs[0] = true;
                WaitForUserInput();
            }
        }
        else if (input == "2")
        {
            if (ifKit.outputs[2] == true)
            {
                ifKit.outputs[2] = false;
                WaitForUserInput();
            }
            else
            {
                ifKit.outputs[2] = true;
                WaitForUserInput();
            }
        }
        else if (input == "3")
        {
            if (ifKit.outputs[3] == true)
            {
                ifKit.outputs[3] = false;
                WaitForUserInput();
            }
            else
            {
                ifKit.outputs[3] = true;
                WaitForUserInput();
            }
        }
        if (input == "5")
        {
            if (ifKit.outputs[5] == true)
            {
                ifKit.outputs[5] = false;
                WaitForUserInput();
            }
            else
            {
                ifKit.outputs[5] = true;
                WaitForUserInput();
            }
        }
        else
        {
            Console.WriteLine("Unknown input. Please select between 0 - 9");
            WaitForUserInput();
        }
    }

    static void ifKit_Attach(object sender, AttachEventArgs e)
    {
        Console.WriteLine("! InterfaceKit {0} attached! " + e.Device.SerialNumber.ToString());
    }

    static void ifKit_Detach(object sender, DetachEventArgs e)
    {
        Console.WriteLine("InterfaceKit {0} detached! " + e.Device.SerialNumber.ToString());
    }

    static void ifKit_Error(object sender, ErrorEventArgs e)
    {
        Console.WriteLine(e.Description);
    }

    static void ifKit_InputChange(object sender, InputChangeEventArgs e)
    {
        Console.WriteLine("Input index {0} value {1}" + " " + e.Index + " " + e.Value.ToString());
    }

    static void ifKit_OutputChange(object sender, OutputChangeEventArgs e)
    {
        Console.WriteLine("Output index {0} value {0}" + " " + e.Index + " " + e.Value.ToString());
    }

    static void ifKit_SensorChange(object sender, SensorChangeEventArgs e)
    {
        Console.WriteLine("Sensor index {0} value {1}" + " " + e.Index + " " + e.Value);
    }
}
