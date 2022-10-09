using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRS;
using BRS.Buttons;
using System.Drawing;
using BRS_Dallas_Programmer.Properties;

namespace BRS_Dallas_Programmer_Icons
{
    /// <summary>
    /// A generic file button's informations
    /// </summary>
    public class fileButtons
    {
        /////////////////////////////////////////////////////////////
        private static EventsColors Default = new EventsColors(Color.Black);


        //////////////////////////////////////////////////////////// - LOADING
        private static Bitmap fileLoading_Default = Resources.icons8_fileLoading_100;
        private static Bitmap fileLoading_Hovering = Resources.icons8_file_loading_100_Selected;
        private static Bitmap fileLoading_Pressing = Resources.icons8_file_loading_100_Selected;
        private static EventsBitmaps fileLoading_Bitmaps;

        //////////////////////////////////////////////////////////// - ACTIVE (DOWNLOAD)
        private static Bitmap fileActive_Default = Resources.icons8_file_download_100;
        private static Bitmap fileActive_Hovering = Resources.icons8_file_download_Selected;
        private static Bitmap fileActive_Pressing = Resources.icons8_file_download_Selected;
        private static EventsBitmaps fileActive_Bitmaps;

        private static EventsColors fileActive = new EventsColors(Color.Black, Color.Black, Color.FromArgb(0,128,255));
        //////////////////////////////////////////////////////////// - Disabled + inactive
        private static Bitmap fileDisabled_Default = Resources.icons8_file_100;
        private static Bitmap fileDisabled_Hovering = Resources.icons8_file_100;
        private static Bitmap fileDisabled_Pressing = Resources.icons8_file_100;
        private static EventsBitmaps fileDisabled_Bitmaps;
        //////////////////////////////////////////////////////////// - Error
        private static Bitmap fileError_Default = Resources.icons8_delete_file_100;
        private static Bitmap fileError_Hovering = Resources.icons8_delete_file_100;
        private static Bitmap fileError_Pressing = Resources.icons8_delete_file_100;
        private static EventsBitmaps fileError_Bitmaps;

        private static EventsColors fileRed = new EventsColors(Color.Black, Color.Black, Color.FromArgb(255, 64, 0));
        //////////////////////////////////////////////////////////// - Warning
        private static Bitmap fileWarning_Default = Resources.icons8_error_file_100;
        private static Bitmap fileWarning_Hovering = Resources.icons8_error_file_100;
        private static Bitmap fileWarning_Pressing = Resources.icons8_error_file_100;
        private static EventsBitmaps fileWarning_Bitmaps;
        ////////////////////////////////////////////////////////////
        private static StatesBitmaps statesBitmaps;
        private static StatesColors statesColors;

        public static StatesColors GetStatesColors()
        {
            statesColors = new StatesColors(Default, fileActive, fileRed, fileRed, Default, Default);
            return (statesColors);
        }

        public static StatesBitmaps GetStatesBitmaps()
        {
            fileLoading_Bitmaps = new EventsBitmaps(fileLoading_Default, fileLoading_Hovering, fileLoading_Pressing);
            fileActive_Bitmaps = new EventsBitmaps(fileActive_Default, fileActive_Hovering, fileActive_Pressing);
            fileDisabled_Bitmaps = new EventsBitmaps (fileDisabled_Default, fileDisabled_Hovering, fileDisabled_Pressing);
            fileError_Bitmaps = new EventsBitmaps(fileError_Default, fileError_Hovering, fileError_Pressing);
            fileWarning_Bitmaps = new EventsBitmaps(fileWarning_Default, fileWarning_Hovering, fileWarning_Pressing);

            statesBitmaps = new StatesBitmaps(fileDisabled_Bitmaps, fileActive_Bitmaps, fileError_Bitmaps, fileWarning_Bitmaps, fileLoading_Bitmaps, fileDisabled_Bitmaps);

            return (statesBitmaps);
        }
    }

    public class connectButton
    {
        /////////////////////////////////////////////////////////////
        private static EventsColors Default = new EventsColors(Color.Black);

        //////////////////////////////////////////////////////////// - ACTIVE (DOWNLOAD)
        private static Bitmap Active_Default = Resources.icons8_connected_100;
        private static Bitmap Active_Hovering = Resources.icons8_connected_selected_100;
        private static Bitmap Active_Pressing = Resources.icons8_connected_selected_100;
        private static EventsBitmaps Active_Bitmaps;

        private static EventsColors Active_Colors = new EventsColors(Color.Black, Color.Black, Color.FromArgb(0, 128, 255));
        private static EventsColors Error_Colors = new EventsColors(Color.Black, Color.Black, Color.FromArgb(255, 64, 0));
        //////////////////////////////////////////////////////////// - Disabled + inactive
        private static Bitmap Disabled_Default = Resources.icons8_disconnected_100;
        private static Bitmap Disabled_Hovering = Resources.icons8_disconnected_selected_100;
        private static Bitmap Disabled_Pressing = Resources.icons8_disconnected_selected_100;
        private static EventsBitmaps Disabled_Bitmaps;
  
        private static StatesBitmaps statesBitmaps;
        private static StatesColors statesColors;

        public static StatesColors GetStatesColors()
        {
            statesColors = new StatesColors(Default, Active_Colors, Error_Colors, Error_Colors, Default, Default);
            return (statesColors);
        }

        public static StatesBitmaps GetStatesBitmaps()
        {
            Active_Bitmaps = new EventsBitmaps(Active_Default, Active_Hovering, Active_Pressing);
            Disabled_Bitmaps = new EventsBitmaps(Disabled_Default, Disabled_Hovering, Disabled_Pressing);

            statesBitmaps = new StatesBitmaps(Disabled_Bitmaps, Active_Bitmaps, Disabled_Bitmaps, Disabled_Bitmaps, Disabled_Bitmaps, Disabled_Bitmaps);

            return (statesBitmaps);
        }
    }
    public class ClearConsolButton
    {
        /////////////////////////////////////////////////////////////
        private static EventsColors Default = new EventsColors(Color.Black);

        //////////////////////////////////////////////////////////// - ACTIVE (DOWNLOAD)
        private static Bitmap Active_Default = Resources.icons8_delete_history_100;
        private static Bitmap Active_Hovering = Resources.icons8_delete_history_100;
        private static Bitmap Active_Pressing = Resources.icons8_delete_history_100;
        private static EventsBitmaps Active_Bitmaps;

        private static EventsColors Active_Colors = new EventsColors(Color.Black, Color.Black, Color.FromArgb(255,255, 64, 0));
        private static EventsColors Error_Colors = new EventsColors(Color.Black, Color.Black, Color.FromArgb(255, 255, 64, 0));
        //////////////////////////////////////////////////////////// - Disabled + inactive
        private static Bitmap Disabled_Default = Resources.icons8_delete_history_disabled_100;
        private static Bitmap Disabled_Hovering = Resources.icons8_delete_history_disabled_100;
        private static Bitmap Disabled_Pressing = Resources.icons8_delete_history_disabled_100;
        private static EventsBitmaps Disabled_Bitmaps;

        private static StatesBitmaps statesBitmaps;
        private static StatesColors statesColors;

        public static StatesColors GetStatesColors()
        {
            statesColors = new StatesColors(Default, Active_Colors, Error_Colors, Error_Colors, Default, Default);
            return (statesColors);
        }

        public static StatesBitmaps GetStatesBitmaps()
        {
            Active_Bitmaps = new EventsBitmaps(Active_Default, Active_Hovering, Active_Pressing);
            Disabled_Bitmaps = new EventsBitmaps(Disabled_Default, Disabled_Hovering, Disabled_Pressing);

            statesBitmaps = new StatesBitmaps(Disabled_Bitmaps, Active_Bitmaps, Disabled_Bitmaps, Disabled_Bitmaps, Disabled_Bitmaps, Disabled_Bitmaps);

            return (statesBitmaps);
        }
    }
}
