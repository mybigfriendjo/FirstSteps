using System;
using System.Windows.Forms;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Input;
using ExampleTest.Helper;

namespace Testdummy.Reference.MyStringTest
{
    public class Example {
       public static void Main() {
            //    Process.Start("H:\\BackupData\\Selftraning\\Programmieren\\ahk\\Sniperfury\\AutoSFAssistent.ahk");
            //    TaskWait(2000);
            //    Process.Start("H:\\BackupData\\Selftraning\\Programmieren\\ahk\\Sniperfury\\KillAutoSFscript.ahk");
            RndMethod();
        }
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void RndMethod() {
            //var process = Process.GetProcessById(4044);
            //  MessageBox.Show(process.ProcessName);
            //process.Kill();

            //string hostName = GetSystemMetrics(SM_CYSCREEN);
            //Console.Write(hostName);
            //MessageBox.Show(hostName);

        }


        Input[] inputs = new Input[]
        {
            new Input {
                type = (int)InputType.Mouse,
                u = new InputUnion {
                    mi = new MouseInput {
                        dx = 100,
                        dy = 100,
                        dwFlags = (uint)(MouseEventF.Move | MouseEventF.LeftDown),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            },
            new Input {
                type = (int)InputType.Mouse,
                u = new InputUnion {
                    mi = new MouseInput {
                        dwFlags = (uint)MouseEventF.LeftUp,
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        SendInput((uint) inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));

        /*
            void MouseSetup(int Mx, int My) {
            Input MiInput = new Input();
            MiInput.type = Input.MOUSEINPUT;
                MiInput.mi.dx = (0 * (0xFFFF / SCREEN_WIDTH));
                MiInput.mi.dy = (0 * (0xFFFF / SCREEN_HEIGHT));
                MiInput.mi.mouseData = 0;
                MiInput.mi.dwFlags = MOUSEEVENTF_ABSOLUTE;
                MiInput.mi.time = 0;
                MiInput.mi.dwExtraInfo = 0;
            Mi
            }
        */
        /*
            void MouseMoveAbsolute(INPUT* buffer, int x, int y) {
                MiInput.mi.dx = (x * (0xFFFF / SCREEN_WIDTH));
                MiInput.mi.dy = (y * (0xFFFF / SCREEN_HEIGHT));
                MiInput.mi.dwFlags = (MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE);

                SendInput(1, buffer, sizeof(INPUT));
            }


            void MouseClick(INPUT* buffer) {
                MiInput.mi.dwFlags = (MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTDOWN);
                SendInput(1, buffer, sizeof(INPUT));

                Sleep(10);

                MiInput.mi.dwFlags = (MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTUP);
                SendInput(1, buffer, sizeof(INPUT));
            }
        }
    }*/
}
