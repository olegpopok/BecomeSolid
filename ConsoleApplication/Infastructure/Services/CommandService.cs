using System;
using System.Collections.Generic;
using ConsoleApplication.Infastructure.Commands;

namespace ConsoleApplication.Infastructure.Services
{
    public class CommandService 
    {
        private IDictionary<string, ICommand> _commands;

        private ICommand _defaultCommand;

        public CommandService(ICommand defaultCommand)
        {
            _commands = new Dictionary<string, ICommand>();

            if (defaultCommand != null)
            {
                _defaultCommand = defaultCommand;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void Add(string name, ICommand command)
        {
            _commands.Add(name, command);
        }

        public ICommand GetByNameOrDefault(string name)
        {
            if (_commands.ContainsKey(name))
            {
                return _commands[name];
            }

            return _defaultCommand;
        }
    }
}
