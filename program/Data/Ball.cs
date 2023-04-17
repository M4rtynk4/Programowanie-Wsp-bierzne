using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Ball : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private int _xposition, _yposition, _radius;
        private int[] Speed = new int[2];

        public Ball(int xposition, int yposition, int radius)
        {
            _xposition = xposition;
            _yposition = yposition;
            _radius = radius;

            int xSpeed = 0;

        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int Xposition
        {

            get { return _xposition; }
            set
            {
                _xposition = value;
                OnPropertyChanged("Xposition");
            }
        }
        public int Yposition
        {

            get { return _yposition; }
            set
            {
                _yposition = value;
                OnPropertyChanged("Yposition");
            }

        }
        public int Radius => _radius;

    


    }



}
