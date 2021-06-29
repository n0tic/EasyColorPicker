using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EasyColorPicker
{
    public class KeyHandler
    {
        /// <summary>
        /// Method to register global hook for hotkey
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="id"></param>
        /// <param name="fsModifiers"></param>
        /// <param name="vk"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        /// <summary>
        /// Method to remove global hook for hotkey
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        // Data
        private int key;

        private IntPtr hWnd;
        private int id;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key"></param>
        /// <param name="form"></param>
        public KeyHandler(Keys key, Form form)
        {
            this.key = (int)key;
            this.hWnd = form.Handle;
            id = this.GetHashCode();
        }

        /// <summary>
        ///  Return hashcode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => key ^ hWnd.ToInt32();

        /// <summary>
        /// Register hotkey
        /// </summary>
        /// <returns></returns>
        public bool Register() => RegisterHotKey(hWnd, id, 0, key);

        /// <summary>
        /// Unregister hotkey
        /// </summary>
        /// <returns></returns>
        public bool Unregiser() => UnregisterHotKey(hWnd, id);
    }
}