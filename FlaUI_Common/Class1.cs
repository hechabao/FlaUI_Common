using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;
using FlaUI.UIA3;
using System;
using System.Text.RegularExpressions;

namespace FlaUI_Common
{
    public class FlaUI_Common
    {
        public class conditions
        {
            public ConditionBase name;
            public ConditionBase classname;
            public ConditionBase automationId;
            public ConditionBase text;
            public ConditionBase controltype;

        }

        public static AutomationElement FindFirstDescendant_StrWindow(Window main, string str)
        {
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            string[] asAllProperties = str.Split(';');

            int iPropertyCount = asAllProperties.Length;
            conditions cons = new conditions();
            ConditionBase con = null;
            AutomationElement item = null;

            //判断输入的字符串是否符合要求
            bool result = Str_Check(str);

            if (result == true)
            {
                //取第一个属性，并将属性转换为Condition
                string[] fKV = Regex.Split(asAllProperties[0], ":=", RegexOptions.IgnoreCase);
                con = ChangeCondition_1(fKV);
                Console.WriteLine("condition = " + con.ToString());

                //取其他属性，并将属性转换为Condition
                for (int i = 1; i < iPropertyCount - 1; i++)
                {
                    string[] aKV = Regex.Split(asAllProperties[i], ":=", RegexOptions.IgnoreCase);
                    con = ChangeCondition_2(con, aKV);
                    Console.WriteLine(con.ToString());
                }

                item = main.FindFirstDescendant(con);
                item.DrawHighlight();
                return item;
            }
            else
            {
                Console.WriteLine("String:" + str + " is not correct, please check it.");
            }
            return item;

        }

        public static AutomationElement FindFirstDescendant_StrElement(AutomationElement main, string str)
        {
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            string[] asAllProperties = str.Split(';');

            int iPropertyCount = asAllProperties.Length;
            conditions cons = new conditions();
            ConditionBase con = null;
            AutomationElement item = null;

            //判断输入的字符串是否符合要求
            bool result = Str_Check(str);

            if (result == true)
            {
                //取第一个属性，并将属性转换为Condition
                string[] fKV = Regex.Split(asAllProperties[0], ":=", RegexOptions.IgnoreCase);
                con = ChangeCondition_1(fKV);
                Console.WriteLine("condition = " + con.ToString());

                //取其他属性，并将属性转换为Condition
                for (int i = 1; i < iPropertyCount - 1; i++)
                {
                    string[] aKV = Regex.Split(asAllProperties[i], ":=", RegexOptions.IgnoreCase);
                    con = ChangeCondition_2(con, aKV);
                    Console.WriteLine(con.ToString());
                }

                item = main.FindFirstDescendant(con);
                item.DrawHighlight();
                return item;
            }
            else
            {
                Console.WriteLine("String:" + str + " is not correct, please check it.");
            }
            return item;
        }

        public static ConditionBase ChangeCondition_1(string[] str)
        {
            ConditionBase con = null;
            conditions cons = new conditions();
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            if (str[0] != "")
            {
                switch (str[0])
                {
                    case "ControlType":
                        cons.controltype = cf.ByControlType(Change_Type(str[1]));
                        con = cons.controltype;
                        break;
                    case "Name":
                        cons.name = cf.ByName(str[1]);
                        con = cons.name;
                        break;
                    case "AutomationId":
                        cons.automationId = cf.ByAutomationId(str[1]);
                        con = cons.automationId;
                        break;
                    case "ClassName":
                        cons.classname = cf.ByClassName(str[1]);
                        con = cons.classname;
                        break;
                    case "Text":
                        cons.text = cf.ByText(str[1]);
                        con = cons.text;
                        break;
                }
            }
            return con;
        }

        public static ConditionBase ChangeCondition_2(ConditionBase con, string[] str)
        {
            conditions cons = new conditions();
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            if (str[0] != "")
            {
                switch (str[0])
                {
                    case "ControlType":
                        cons.controltype = cf.ByControlType(Change_Type(str[1]));
                        con = con.And(cons.controltype);
                        break;
                    case "Name":
                        cons.name = cf.ByName(str[1]);
                        con = con.And(cf.ByName(str[1]));
                        break;
                    case "AutomationId":
                        cons.automationId = cf.ByAutomationId(str[1]);
                        con = con.And(cf.ByAutomationId(str[1]));
                        break;
                    case "ClassName":
                        cons.classname = cf.ByClassName(str[1]);
                        con = con.And(cf.ByClassName(str[1]));
                        break;
                    case "Text":
                        cons.text = cf.ByText(str[1]);
                        con = con.And(cf.ByText(str[1]));
                        break;
                }
            }
            return con;
        }

        public static AutomationElement[] FindAllDescendants_StrWindow(Window main, string str)
        {
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            string[] asAllProperties = str.Split(';');
            int iPropertyCount = asAllProperties.Length;
            AutomationElement[] item = null;

            //判断输入的字符串是否符合要求
            bool result = Str_Check(str);

            if (result == true)
            {
                //取第一个属性，并将属性转换为Condition
                string[] fKV = Regex.Split(asAllProperties[0], ":=", RegexOptions.IgnoreCase);
                ConditionBase con = ChangeCondition_1(fKV);
                Console.WriteLine("condition = " + con.ToString());

                //取其他属性，并将属性转换为Condition
                for (int i = 1; i < iPropertyCount - 1; i++)
                {
                    string[] aKV = Regex.Split(asAllProperties[i], ":=", RegexOptions.IgnoreCase);
                    con = ChangeCondition_2(con, aKV);
                    Console.WriteLine(con.ToString());
                }

                item = main.FindAllDescendants(con);
            }
            else
            {
                Console.WriteLine("String:" + str + " is not correct, please check it.");
            }

            return item;
        }

        public static AutomationElement[] FindAllDescendants_StrElement(AutomationElement main, string str)
        {
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            string[] asAllProperties = str.Split(';');
            int iPropertyCount = asAllProperties.Length;
            AutomationElement[] item = null;

            //判断输入的字符串是否符合要求
            bool result = Str_Check(str);

            if (result == true)
            {
                //取第一个属性，并将属性转换为Condition
                string[] fKV = Regex.Split(asAllProperties[0], ":=", RegexOptions.IgnoreCase);
                ConditionBase con = ChangeCondition_1(fKV);
                Console.WriteLine("condition = " + con.ToString());

                //取其他属性，并将属性转换为Condition
                for (int i = 1; i < iPropertyCount - 1; i++)
                {
                    string[] aKV = Regex.Split(asAllProperties[i], ":=", RegexOptions.IgnoreCase);
                    con = ChangeCondition_2(con, aKV);
                    Console.WriteLine(con.ToString());
                }

                item = main.FindAllDescendants(con);
            }
            else
            {
                Console.WriteLine("String:" + str + " is not correct, please check it.");
            }
            return item;
        }

        public static AutomationElement FindFirstChild_StrElement(AutomationElement main, string str)
        {
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            string[] asAllProperties = str.Split(';');
            int iPropertyCount = asAllProperties.Length;
            AutomationElement item = null;

            //判断输入的字符串是否符合要求
            bool result = Str_Check(str);

            if (result == true)
            {
                //取第一个属性，并将属性转换为Condition
                string[] fKV = Regex.Split(asAllProperties[0], ":=", RegexOptions.IgnoreCase);
                ConditionBase con = ChangeCondition_1(fKV);
                Console.WriteLine("condition = " + con.ToString());

                //取其他属性，并将属性转换为Condition
                for (int i = 1; i < iPropertyCount - 1; i++)
                {
                    string[] aKV = Regex.Split(asAllProperties[i], ":=", RegexOptions.IgnoreCase);
                    con = ChangeCondition_2(con, aKV);
                    Console.WriteLine(con.ToString());
                }

                item = main.FindFirstChild(con);
            }
            else
            {
                Console.WriteLine("String:" + str + " is not correct, please check it.");
            }
            return item;

        }

        public static bool Str_Check(string str)
        {
            //判断输入的str是否符合要求，即"="与";"数量一致
            bool result;
            result = (Regex.Matches(str, ";").Count == Regex.Matches(str, "=").Count) ? true : false;
            return result;
        }

        public static ControlType Change_Type(string str_type)
        {
            ControlType ele_type = ControlType.Button;
            switch (str_type)
            {
                case "Button":
                    ele_type = ControlType.Button;
                    break;
                case "CheckBox":
                    ele_type = ControlType.CheckBox;
                    break;
                case "DataItem":
                    ele_type = ControlType.DataItem;
                    break;
                case "Group":
                    ele_type = ControlType.Group;
                    break;
                case "Image":
                    ele_type = ControlType.Image;
                    break;
                case "List":
                    ele_type = ControlType.List;
                    break;
                case "ListItem":
                    ele_type = ControlType.ListItem;
                    break;
                case "":
                    ele_type = ControlType.Menu;
                    break;
                case "MenuItem":
                    ele_type = ControlType.MenuItem;
                    break;
                case "Pane":
                    ele_type = ControlType.Pane;
                    break;
                case "ScrollBar":
                    ele_type = ControlType.ScrollBar;
                    break;
                case "Window":
                    ele_type = ControlType.Window;
                    break;
                case "TitleBar":
                    ele_type = ControlType.TitleBar;
                    break;
            }
            return ele_type;
        }

        public static AutomationElement GetDesktop()
        {
            var automation = new UIA3Automation();
            var deskTop = automation.GetDesktop();
            return deskTop;
        }

        public static void Window_Action(AutomationElement windows, string action)
        {
            IWindowPattern windowpattern = windows.Patterns.Window.Pattern;
            switch (action.ToLower())
            {
                case "max":
                    windowpattern.SetWindowVisualState(WindowVisualState.Maximized);
                    break;
                case "min":
                    windowpattern.SetWindowVisualState(WindowVisualState.Minimized);
                    break;
                case "normal":
                    windowpattern.SetWindowVisualState(WindowVisualState.Normal);
                    break;
                case "close":
                    windowpattern.Close();
                    break;

            }
        }
    }
}
