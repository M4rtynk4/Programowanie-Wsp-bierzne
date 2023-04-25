using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    internal class UserCommand : ICommand
    { // akcja, która zostanie wykonana, gdy użytkownik wywoła polecenie
        private readonly Action execute;
        // funkcja logiczna, która określa, czy ta akcja może zostać wykonana
        private readonly Func<bool> canExecute;

        public event EventHandler CanExecuteChanged;

        public UserCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public UserCommand(Action execute) : this(execute, null) { }

        public virtual void Execute(object obj)
        {
            this.execute();
        }
        
        public bool CanExecute(object obj)
        {
            if (this.canExecute == null)
            {
                return true;
            }
            if (obj == null)
            {
                return this.canExecute();
            }
            return this.canExecute();
        }
        // Metoda RaiseCanExecuteChanged jest używana do wywołania zdarzenia CanExecuteChanged, 
        // które umożliwia odświeżenie widoku, gdy zmienia się zdolność do wykonania akcji.
        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
