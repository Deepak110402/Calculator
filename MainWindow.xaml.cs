using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        decimal number, secondNumber;
        string operation = Constants.NullString;
        bool isOperation = false;

        /// <summary>
        /// Method <c>MainWindow</c> initialize the components of xml file
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method <c>ButtonClick</c> wiil be called when user press numbers button
        /// </summary>
        /// <param name="sender">object details of button</param>
        /// <param name="e">Routed event arguments</param>
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (InputedText.Text.Length > 3
                && InputedText.Text[InputedText.Text.Length - 2] == Constants.Equal[1])
            {
                InputedText.Text = Constants.NullString;
                ResultedText.Text = Constants.ZeroString;
                operation = Constants.NullString;
            }
            if (isOperation == true)
                ResultedText.Text = Constants.NullString;
            if (ResultedText.Text == Constants.ZeroString)
                ResultedText.Text = Constants.NullString;
            if (ResultedText.Text.Length < 9
                && ResultedText.Text != Constants.ResultError
                && ResultedText.Text != Constants.DivideError)
            {
                Button button = (Button)sender;
                ResultedText.Text += button.Name[1];
            }
            isOperation = false;
        }

        /// <summary>
        /// Method <c>EqualClick</c> wiil be called when user press Equal button
        /// </summary>
        /// <param name="sender">object details of button</param>
        /// <param name="e">Routed event arguments</param>
        private void EqualClick(object sender, RoutedEventArgs e)
        {
            MainOperation();
            if (InputedText.Text.Length > InputedText.MaxLength)
                CutInputedText();
            if (ResultedText.Text != Constants.ResultError
                && ResultedText.Text != Constants.DivideError)
            {
                if (InputedText.Text.Length > 3)
                {
                    if (InputedText.Text[InputedText.Text.Length - 2] != Constants.Equal[1])
                        InputedText.Text += Constants.Equal;
                }
                else
                {
                    InputedText.Text += Constants.Equal;
                }
            }
        }

        /// <summary>
        /// Method <c>plusClick</c> wiil be called when user press plus button
        /// </summary>
        /// <param name="sender">object details of button</param>
        /// <param name="e">Routed event arguments</param>
        private void PlusClick(object sender, RoutedEventArgs e)
        {
            OperationClick();
            if (ResultedText.Text != Constants.ResultError
                && ResultedText.Text != Constants.DivideError)
                InputedText.Text += Constants.Plus;
            if (InputedText.Text.Length > InputedText.MaxLength)
                CutInputedText();
            operation = Constants.AddOperation;
        }

        /// <summary>
        /// Method <c>MinusClick</c> wiil be called when user press minus button
        /// </summary>
        /// <param name="sender">object details of button</param>
        /// <param name="e">Routed event arguments</param>
        private void MinusClick(object sender, RoutedEventArgs e)
        {
            OperationClick();
            if (ResultedText.Text != Constants.ResultError
                && ResultedText.Text != Constants.DivideError)
                InputedText.Text += Constants.Minus;
            if (InputedText.Text.Length > InputedText.MaxLength)
                CutInputedText();
            operation = Constants.MinusOperation;
        }

        /// <summary>
        /// Method <c>MultiplyClick</c> wiil be called when user press multiply button
        /// </summary>
        /// <param name="sender">object details of button</param>
        /// <param name="e">Routed event arguments</param>
        private void MultiplyClick(object sender, RoutedEventArgs e)
        {
            OperationClick();
            if (ResultedText.Text != Constants.ResultError
                && ResultedText.Text != Constants.DivideError)
                InputedText.Text += Constants.Multiply;
            if (InputedText.Text.Length > InputedText.MaxLength)
                CutInputedText();
            operation = Constants.MultiplyOperation;
        }

        /// <summary>
        /// Method <c>DivideClick</c> wiil be called when user press Divide button
        /// </summary>
        /// <param name="sender">object details of button</param>
        /// <param name="e">Routed event arguments</param>    
        private void DivideClick(object sender, RoutedEventArgs e)
        {
            OperationClick();
            if (ResultedText.Text != Constants.ResultError
                && ResultedText.Text != Constants.DivideError)
                InputedText.Text += Constants.Divide;
            if (InputedText.Text.Length > InputedText.MaxLength)
                CutInputedText();
            operation = Constants.DivideOperation;
        }

        /// <summary>
        /// Method <c>ClearClick</c> wiil be called when user press clear button
        /// </summary>
        /// <param name="sender">object details of button</param>
        /// <param name="e">Routed event arguments</param>
        private void ClearClick(object sender, RoutedEventArgs e)
        {
            InputedText.Text = null;
            ResultedText.Text = Constants.ZeroString;
            operation = Constants.NullString;
            number = 0;
            secondNumber = 0;
        }

        /// <summary>
        /// Method <c>DotClick</c> wiil be called when user press dot button
        /// </summary>
        /// <param name="sender">object details of button</param>
        /// <param name="e">Routed event arguments</param>
        private void DotClick(object sender, RoutedEventArgs e)
        {
            isOperation = false;
            if (ResultedText.Text != Constants.ResultError
                && ResultedText.Text != Constants.DivideError)
            {
                if (ResultedText.Text == Constants.ZeroString)
                {
                    if (!ResultedText.Text.Contains(Constants.Dot))
                    {
                        ResultedText.Text = Constants.NullString;
                        ResultedText.Text += Constants.ZeroString;
                        ResultedText.Text += Constants.Dot;
                    }
                }
                else if (InputedText.Text.Length > 3 && number.ToString() == ResultedText.Text)
                {
                    if (InputedText.Text[InputedText.Text.Length - 2] == Constants.Equal[1])
                    {
                        InputedText.Text = Constants.NullString;
                        ResultedText.Text = Constants.ZeroString;
                        ResultedText.Text += Constants.Dot;
                        operation = Constants.NullString;
                    }
                }
                else
                {
                    if (!ResultedText.Text.Contains(Constants.Dot))
                    {
                        ResultedText.Text += Constants.Dot;
                    }
                }
            }
            
        }

        /// <summary>
        /// Method <c>BackSpaceClick</c> wiil be called when user press BackSpace button
        /// </summary>
        /// <param name="sender">object details of button</param>
        /// <param name="e">Routed event arguments</param>
        private void BackSpaceClick(object sender, RoutedEventArgs e)
        {
            if (ResultedText.Text == Constants.ResultError
                || ResultedText.Text == Constants.DivideError)
            {
                InputedText.Text = Constants.NullString;
                ResultedText.Text = Constants.ZeroString;
            }
            else
            {
                if (ResultedText.Text.Length == 1)
                    ResultedText.Text = Constants.ZeroString;
                else
                    ResultedText.Text = ResultedText.Text.Substring(0, ResultedText.Text.Length - 1);
            }
        }

        /// <summary>
        /// Method <c>Click</c> checks conditions and stores first number in resultvalue
        /// </summary>
        public void OperationClick()
        {
            if (ResultedText.Text == Constants.ZeroString)
            {
                InputedText.Text = Constants.ZeroString;
            }
            else if (InputedText.Text.EndsWith(Constants.SpaceChar.ToString())
                     && InputedText.Text[InputedText.Text.Length - 2] == Constants.Equal[1])
            {
                InputedText.Text = InputedText.Text.Substring(0, InputedText.Text.Length - 3);
            }
            else if (ResultedText.Text != Constants.ResultError
                     && ResultedText.Text != Constants.DivideError)
            {
                MainOperation();
            }
            isOperation = true;
        }

        /// <summary>
        /// Method <c>MainOperation</c> calculates the result and prints the result
        /// </summary>
        public void MainOperation()
        {
            if (ResultedText.Text.EndsWith(Constants.Dot))
            {
                ResultedText.Text += Constants.ZeroString;
            }
            else if (InputedText.Text.Length > 3
                && InputedText.Text[InputedText.Text.Length - 2] == Constants.Equal[1])
            {
                if (InputedText.Text.Count(s => s == Constants.SpaceChar) != 2)
                {
                    InputedText.Text = InputedText.Text.Substring(0, InputedText.Text.Length - 3);
                    if (operation == Constants.AddOperation)
                        InputedText.Text += Constants.Plus;
                    else if (operation == Constants.MinusOperation)
                        InputedText.Text += Constants.Minus;
                    else if (operation == Constants.MultiplyOperation)
                        InputedText.Text += Constants.Multiply;
                    else if (operation == Constants.DivideOperation)
                        InputedText.Text += Constants.Divide;
                    InputedText.Text += secondNumber.ToString();
                    ResultedText.Text = secondNumber.ToString();
                    SwitchCase();
                }
            }
            else
            {
                if (ResultedText.Text != Constants.DivideError && ResultedText.Text != Constants.ResultError)
                {
                    if (InputedText.Text.Length > InputedText.MaxLength)
                        CutInputedText();
                    InputedText.Text += ResultedText.Text;
                    if (!InputedText.Text.Contains(Constants.SpaceChar))
                        number = Convert.ToDecimal(InputedText.Text);
                    else
                        SwitchCase();
                }
            }
        }

        /// <summary>
        /// Method <c>SwitchCase</c> calculates and prints the value according to operation
        /// </summary>
        public void SwitchCase()
        {
            switch (operation)
            {
                case Constants.AddOperation:
                    secondNumber = Convert.ToDecimal(ResultedText.Text);
                    number += secondNumber;
                    if (number.ToString().Length > 9)
                    { 
                        ResultedText.Text = Constants.ResultError;
                        InputedText.Text = Constants.NullString;
                    }
                    else
                        ResultedText.Text = number.ToString();
                    break;
                case Constants.MinusOperation:
                    secondNumber = Convert.ToDecimal(ResultedText.Text);
                    number -= secondNumber;
                    if (number.ToString().Length > 9)
                    {
                        ResultedText.Text = Constants.ResultError;
                        InputedText.Text = Constants.NullString;
                    }
                    else
                        ResultedText.Text = number.ToString();
                    break;
                case Constants.MultiplyOperation:
                    secondNumber = Convert.ToDecimal(ResultedText.Text);
                    number *= secondNumber;
                    if (number.ToString().Length > 9)
                    {
                        ResultedText.Text = Constants.ResultError;
                        InputedText.Text = Constants.NullString;
                    }
                    else
                        ResultedText.Text = number.ToString();
                    break;
                case Constants.DivideOperation:
                    secondNumber = Convert.ToDecimal(ResultedText.Text);
                    try
                    {
                        number /= secondNumber;
                        if (number.ToString().Length > 9)
                            number = Convert.ToDecimal(number.ToString().Substring(0, 9));
                        ResultedText.Text = number.ToString();
                    }
                    catch
                    {
                        ResultedText.Text = Constants.DivideError;
                        InputedText.Text = Constants.NullString;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Mehtod <c>CutInputedText</c> remove the first operation when reaches the max length
        /// </summary>
        public void CutInputedText()
        {
            for (int index = 0; index < InputedText.Text.Length; index++)
            {
                if (InputedText.Text[index] == Constants.SpaceChar)
                {
                    InputedText.Text = InputedText.Text.Substring(index + 3);
                    break;
                }
            }
        }

        /// <summary>
        /// Method <c>WindowKeyDown</c> press button according to the keyboard input
        /// </summary>
        /// <param name="sender">object details of button</param>
        /// <param name="e">Key event arguments</param>
        private void WindowKeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.D8) && Keyboard.IsKeyDown(Key.RightShift))
            {
                MultiplyClick(multiply, e);
            }
            else
            {
                switch (e.Key)
                {
                    case Key.Escape:
                        ClearClick(clear, e);
                        break;
                    case Key.Back:
                        BackSpaceClick(backspace, e);
                        break;
                    case Key.Return:
                        EqualClick(equal, e);
                        break;
                    case Key.Add:
                        PlusClick(plus, e);
                        break;
                    case Key.Subtract:
                        MinusClick(minus, e);
                        break;
                    case Key.Multiply:
                        MultiplyClick(multiply, e);
                        break;
                    case Key.Divide:
                        DivideClick(divide, e);
                        break;
                    case Key.Decimal:
                        DotClick(dot, e);
                        break;
                    case Key.NumPad1:
                        ButtonClick(_1, e);
                        break;
                    case Key.NumPad0:
                        ButtonClick(_0, e);
                        break;
                    case Key.NumPad2:
                        ButtonClick(_2, e);
                        break;
                    case Key.NumPad3:
                        ButtonClick(_3, e);
                        break;
                    case Key.NumPad4:
                        ButtonClick(_4, e);
                        break;
                    case Key.NumPad5:
                        ButtonClick(_5, e);
                        break;
                    case Key.NumPad6:
                        ButtonClick(_6, e);
                        break;
                    case Key.NumPad7:
                        ButtonClick(_7, e);
                        break;
                    case Key.NumPad8:
                        ButtonClick(_8, e);
                        break;
                    case Key.NumPad9:
                        ButtonClick(_9, e);
                        break;
                    case Key.D0:
                        ButtonClick(_0, e);
                        break;
                    case Key.D1:
                        ButtonClick(_1, e);
                        break;
                    case Key.D2:
                        ButtonClick(_2, e);
                        break;
                    case Key.D3:
                        ButtonClick(_3, e);
                        break;
                    case Key.D4:
                        ButtonClick(_4, e);
                        break;
                    case Key.D5:
                        ButtonClick(_5, e);
                        break;
                    case Key.D6:
                        ButtonClick(_6, e);
                        break;
                    case Key.D7:
                        ButtonClick(_7, e);
                        break;
                    case Key.D8:
                        ButtonClick(_8, e);
                        break;
                    case Key.D9:
                        ButtonClick(_9, e);
                        break;
                    case Key.OemPlus:
                        PlusClick(plus, e);
                        break;
                    case Key.OemMinus:
                        MinusClick(minus, e);
                        break;
                    case Key.OemQuestion:
                        DivideClick(divide, e);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}