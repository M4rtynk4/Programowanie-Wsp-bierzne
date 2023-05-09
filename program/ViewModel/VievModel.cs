using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

using Model;
using System.Collections.ObjectModel;

namespace ViewModel
{
    //Klasa ViewModel zawiera implementację interfejsu INotifyPropertyChanged,
    //który jest używany do powiadamiania widoku o zmianach w modelu.
    public class ViewModel : INotifyPropertyChanged
    {
        private ModelAbstractApi modelApi;
        //Zdefiniowanie kolekcji BallModel, która przechowuje modele piłek, oraz właściwości i metody obsługi interakcji użytkownika.
        public ObservableCollection<BallModel> balls { get; set; }
        //Polecenie obsługujące kliknięcie przycisku START
        public ICommand StartButtonClicked { get; set; }
        //Wartość wprowadzona przez użytkownika w polu tekstowym
        public ICommand StopButtonClicked { get; set; }
        private string text;
        private Task task;
        //Wartość logiczna wskazująca, czy program jest w trybie aktywnym
        private bool active;
        //Wartość logiczna wskazująca, czy program jest w trybie nieaktywnym
        private bool notActive = false;
        //Informacje o błędzie wprowadzonych danych
        private string errorMessage;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel() : this(ModelAbstractApi.CreateApi())
        {

        }

        public ViewModel(ModelAbstractApi baseModel)
        {
            Active = true;
            this.modelApi = baseModel;
            StartButtonClicked = new UserCommand(() => StartButtonClickHandler());
            balls = new ObservableCollection<BallModel>();
            StopButtonClicked = new UserCommand(() => StopButtonClickHandler());

        }

        //StartButtonClickHandler() - metoda obsługująca kliknięcie przycisku Start. Pobiera wartość wprowadzoną
        //przez użytkownika w polu tekstowym, wywołuje metodę modelApi.addBalls() i uruchamia metodę ChangePosition() na nowym wątku (Task).
        private void StartButtonClickHandler()
        {
            modelApi.addBalls(readFromBox());
            task = new Task(ChangePosition);
            task.Start();
            
        }
        private void StopButtonClickHandler()
        {
            modelApi.removeBalls();
            readFromBox();
           
        }

        //ChangePosition() jest asynchroniczną metodą, która w nieskończonej pętli aktualizuje pozycje piłek w kolekcji balls.
        public void ChangePosition()
        {
            while (true)
            {
                ObservableCollection<BallModel> ballsList = new ObservableCollection<BallModel>();

                foreach (BallModel ball in modelApi.balls)
                {
                    ballsList.Add(ball);
                }
                balls = ballsList;
                RaisePropertyChanged(nameof(balls));
                Thread.Sleep(1);
            }
        }

        //RaisePropertyChanged() informuje widok o zmianach w kolekcji balls.
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //readFromBox() - metoda, która konwertuje wartość wprowadzoną przez użytkownika w polu tekstowym na liczbę całkowitą.
        //Metoda zwraca tę liczbę lub 0, jeśli wartość wprowadzona jest nieprawidłowa.
        //Metoda ustawia również właściwości Active i NotActive na true lub false w zależności
        public int readFromBox()
        {
            int result;
            if (Int32.TryParse(TextMethod, out result) && TextMethod != "0")
            {
                result = Int32.Parse(TextMethod);
                ErrorMessage = " ";
                Active = !Active;
                NotActive = !NotActive;
                return result;
            }
            ErrorMessage = "Podaj liczbę!";
            return 0;
        }

        public bool NotActive
        {
            get
            {
                return notActive;
            }
            set
            {
                notActive = value;
                RaisePropertyChanged(nameof(NotActive));
            }
        }

        public bool Active
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
                RaisePropertyChanged(nameof(Active));
            }
        }

        public string TextMethod
        {
            get { return text; }
            set
            {
                text = value;
                RaisePropertyChanged(nameof(TextMethod));
            }
        }


        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                errorMessage = value;
                RaisePropertyChanged(nameof(ErrorMessage));
            }
        }
    }
}