using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace IconTool.Helper
{
    public static class AppCommands
    {
        public static ICommand Closed
        {
            get
            {
                return _EnsureCommand(EnumCommand.Closed, () =>
                {
                    return new DelegateCommand<Window>((win) =>
                    {
                        win.Close();
                    });
                });
            }
        }

        public static ICommand DragMove {
            get {
                return _EnsureCommand(EnumCommand.DragMove, () =>
                {
                    return new DelegateCommand<Window>((win) =>
                    {
                        win.DragMove();
                        //win.WindowState = WindowState.Maximized;
                    });
                });
            }
        }

        public static ICommand Maximized {
            get
            {
                return _EnsureCommand(EnumCommand.Maximized, () =>
                {
                    return new DelegateCommand<Window>((win) =>
                    {
                        win.WindowState = WindowState.Maximized;
                    });
                });
            }
        }

        public static ICommand Minimized
        {
            get
            {
                return _EnsureCommand(EnumCommand.Minimized, () =>
                {
                    return new DelegateCommand<Window>((win) =>
                    {
                        win.WindowState = WindowState.Minimized;
                    });
                });
            }
        }

        public static ICommand WindowStateNormal
        {
            get
            {
                return _EnsureCommand(EnumCommand.WindowStateNormal, () =>
                {
                    return new DelegateCommand<Window>((win) =>
                    {
                        win.WindowState = WindowState.Normal;
                    });
                });
            }
        }




        private enum EnumCommand
        {
            Closed = 0,

            DragMove = 1,

            Maximized,

            Minimized,

            WindowStateNormal,

            Last,
        }

        private static ICommand[] _internalCommands = new ICommand[(int)EnumCommand.Last];

        private static ICommand _EnsureCommand(EnumCommand idCommand, Func<ICommand> func)
        {
            if (idCommand >= 0 && idCommand < EnumCommand.Last)
            {
                lock (_internalCommands.SyncRoot)
                {
                    if (_internalCommands[(int)idCommand] == null)
                    {
                        _internalCommands[(int)idCommand] = func?.Invoke();
                    }
                }
                return _internalCommands[(int)idCommand];
            }
            return null;
        }
    }
}
