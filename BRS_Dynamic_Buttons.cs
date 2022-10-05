using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BRS;

namespace BRS
{
    public class Smoothing
    {
        public static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * t;
        }
    }

    public partial class TriStateButton : Button
    {
        /// <summary>
        /// Enables or disable the button.
        /// While disabled, no actions are done with the button.
        /// IconDisabled will be shown until re-enabled
        /// </summary>
        private bool enabled = true;

        /// <summary>
        /// Setting to true will use bitmap Good.
        /// Setting to false will use bitmap Bad.
        /// </summary>
        public bool state = false;
        /// <summary>
        /// Zoom in on the button when the cursor enters the button
        /// while it is enabled
        /// </summary>
        public bool ChangeSizeWhenMouseHover = false;
        /// <summary>
        /// By how much the button's size should change when the mouse is hovering above.
        /// 0.5 = half, 1 = Same, 2 = 2 times... ect
        /// </summary>
        public float SizeMultiplier_MouseHover = 1.2f;

        /// <summary>
        /// Change the button's size while the cursor is pressed on the button
        /// until it is released.
        /// </summary>
        public bool ChangeSizeWhenClicked = false;
        /// <summary>
        ///  Target size for the button when clicking on it.
        ///  0.5 = Half, 1 = Same, 2 = 2 times... ect
        /// </summary>
        public float SizeMultiplier_Clicking = 0.9f;

        /// <summary>
        /// Third parameter of a lerp function. You'll need to tune it according to your timer's intervals
        /// 1 = Instant.
        /// </summary>
        public float LerpingSpeed = 0.25f;

        /// <summary>
        /// Decides if your button should animate using Lerps.
        /// IF TRUE, CALL BUTTON IN A PERIODIC TIMER
        /// </summary>
        public bool Animated = false;

        /// <summary>
        /// Bitmap background image used on the button while it is not enabled
        /// </summary>
        public Bitmap IconDisabled;
        /// <summary>
        /// Bitmap to use when your button is ON / Available / Correct ect
        /// </summary>
        public Bitmap IconGood;
        /// <summary>
        /// Bitmap displayed on your button when it is: Disabled / Unavailable / Off ect
        /// </summary>
        public Bitmap IconBad;

        /// <summary>
        /// Which colour your button should have as background when pressed
        /// Defaults to transparent
        /// </summary>
        public Color PressedColor = Color.Empty;
        /// <summary>
        /// Which colour your button should have as background when the cursor is above
        /// Defaults to transparent
        /// </summary>
        public Color HoveringColor = Color.Empty;

        private float currentR = 0;
        private float currentG = 0;
        private float currentB = 0;
        private Color wantedColor = Color.Empty;

        private float currentSizeMultiplier = 1;

        private float wantedSizeMultiplier = 1;

        private int OriginalWidth;
        private int OriginalHeight;
        private int OriginalX;
        private int OriginalY;

        private bool Pressed = false;

        public Button FormButton;

        //#############################################################//
        //#############################################################//
        public TriStateButton(Button referencedButton)
        {
            BRS.Debug.Header(true);
            BRS.Debug.Comment("Creating Tri state button. Gathering referenced button's information");

            FormButton = referencedButton;

            OriginalWidth = FormButton.Size.Width;
            OriginalHeight = FormButton.Size.Height;

            OriginalX = FormButton.Location.X;
            OriginalY = FormButton.Location.Y;

            FormButton.BackgroundImageLayout = ImageLayout.Stretch;
            FormButton.BackgroundImageLayout = ImageLayout.Stretch;
            //this.InformationButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InformationButton_MouseDown);
            FormButton.MouseEnter += (sender, args) => {Button_MouseEnter();};
            FormButton.MouseLeave += (sender, args) => { Button_MouseLeave(); };
            FormButton.MouseDown += (sender, args) => { Button_MouseDown(); };
            FormButton.MouseUp += (sender, args) => { Button_MouseUp(); };

            //FormButton.FlatAppearance.MouseDownBackColor = Color.Empty;
            //FormButton.FlatAppearance.MouseOverBackColor = Color.Empty;

            BRS.Debug.Header(false);
        }
        //#############################################################//
        /// <summary>
        /// Allows you to set all 3 available bitmaps in 1 function.
        /// </summary>
        /// <param name="Disabled">when enabled = false</param>
        /// <param name="ON">Good / available / ON</param>
        /// <param name="OFF">Bad / Unavailable / error / off</param>
        //#############################################################//
        public void SetAllBitmaps(Bitmap Disabled, Bitmap ON, Bitmap OFF)
        {
            BRS.Debug.Header(true);
            BRS.Debug.Comment("Setting standard bitmaps for this button");

            IconDisabled = Disabled;
            IconGood = ON;
            IconBad = OFF;

            BRS.Debug.Success("No error occured");
            BRS.Debug.Header(false);
        }
        //#############################################################//
        /// <summary>
        /// Disables the button. Button.Enabled = false;
        /// </summary>
        //#############################################################//
        public void Disable()
        {
            // Disabling "enable"
            FormButton.Enabled = false;
            enabled = false;

            // Putting size & highlight to regular
            wantedSizeMultiplier = 1;

            // Specify wanted colour
            wantedColor = Color.Empty;
        }
        //#############################################################//
        /// <summary>
        /// Enables the button. Button.Enabled = true;
        /// </summary>
        //#############################################################//
        public void Enable()
        {
            // Disabling "enable"
            enabled = true;
            FormButton.Enabled = true;
        }
        //#############################################################//
        /// <summary>
        /// Function to call in a periodic timer if Animate is set to true.
        /// This will update the button's background images, sizes and 
        /// highlight colours.
        /// </summary>
        //#############################################################//
        public void Update()
        {
            //BRS.Debug.Comment(FormButton.BackColor.ToString());

            if(Animated)
            {
                if (!Pressed)
                {
                    // Lerp colour to wanted colour
                    int R = wantedColor.R;
                    int G = wantedColor.G;
                    int B = wantedColor.B;

                    float wR = (float)R;
                    float wG = (float)G;
                    float wB = (float)B;

                    currentR = Smoothing.Lerp(currentR, wR, LerpingSpeed);
                    currentG = Smoothing.Lerp(currentG, wG, LerpingSpeed);
                    currentB = Smoothing.Lerp(currentB, wB, LerpingSpeed);

                    R = (int)currentR;
                    G = (int)currentG;
                    B = (int)currentB;

                    FormButton.BackColor = Color.FromArgb(R, G, B);
                }
                //////////////////////////////////////////////////////
                currentSizeMultiplier = Smoothing.Lerp(currentSizeMultiplier, wantedSizeMultiplier, LerpingSpeed);

                float originalHeight    = (float)OriginalHeight;
                float originalWidth     = (float)OriginalWidth;
                float originalPositionX = (float)OriginalX;
                float originalPositionY = (float)OriginalY;

                float newHeight = originalHeight * currentSizeMultiplier;
                float newWidth = originalWidth * currentSizeMultiplier;

                float heightDifference = originalHeight - newHeight;
                float widthDifference = originalWidth - newWidth;

                float newX = originalPositionX + widthDifference/2;
                float newY = originalPositionY + heightDifference/2;

                FormButton.Location = new Point((int)newX, (int)newY);
                FormButton.Size = new Size((int)newWidth, (int)newHeight);

            }
            else //////////////////////////////////////////////////////
            {

                FormButton.BackColor = wantedColor;
            }

            if (FormButton.Enabled == false)
            {
                FormButton.BackgroundImage = IconDisabled;
            }
            else
            {
                if (state)
                {
                    if (IconGood != null)
                    {
                        FormButton.BackgroundImage = IconGood;
                    }
                }
                else
                {
                    if (IconBad != null)
                    {
                        FormButton.BackgroundImage = IconBad;
                    }
                }
            }
        }
        //#############################################################//
        //#############################################################//
        private void Button_MouseEnter()
        {
            if(enabled)
            {
                wantedColor = HoveringColor;
                currentR = (float)wantedColor.R;
                currentG = (float)wantedColor.G;
                currentB = (float)wantedColor.B;

                // size
                wantedSizeMultiplier = SizeMultiplier_MouseHover;
            }
        }
        //#############################################################//
        //#############################################################//
        private void Button_MouseLeave()
        {
            Pressed = false;
            wantedColor = Color.Empty;

            // size
            wantedSizeMultiplier = 1;
        }
        //#############################################################//
        //#############################################################//
        private void Button_MouseDown()
        {
            if (enabled)
            {
                wantedColor = PressedColor;

                // size
                wantedSizeMultiplier = SizeMultiplier_Clicking;
                currentSizeMultiplier = wantedSizeMultiplier;

                currentR = (float)wantedColor.R;
                currentG = (float)wantedColor.G;
                currentB = (float)wantedColor.B;

                FormButton.BackColor = wantedColor;

                Pressed = true;
            }
        }
        //#############################################################//
        //#############################################################//
        private void Button_MouseUp()
        {
            if (enabled)
            {
                wantedColor = HoveringColor;

                // size
                wantedSizeMultiplier = SizeMultiplier_MouseHover;
                Pressed = false;
            }
        }
    }
}
