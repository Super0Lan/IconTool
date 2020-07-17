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

        private enum EnumCommand
        {
            Closed = 0,
            Last = 1,
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
