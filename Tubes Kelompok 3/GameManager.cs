using System;
using System.Collections.Generic;
using Tubes_Kelompok_3.Interface;

namespace Tubes_Kelompok_3
{
    public enum AlurGame { NULL, MAIN_MENU, MENU_PILIH_MODE, MODE_MEMILIH_KATA, MODE_GAMBAR, MODE_MENCOCOKAN_KATA }

    public static class GameManager
    {
        private static readonly List<IGameObserver<AlurGame>> _observers = new List<IGameObserver<AlurGame>>();
        private static AlurGame _alurSaatIni = AlurGame.NULL;

        public static void Attach(IGameObserver<AlurGame> observer)
        {
            if (observer == null) throw new ArgumentNullException(nameof(observer));
            if (!_observers.Contains(observer)){
                _observers.Add(observer);
            }
        }

        public static void Detach(IGameObserver<AlurGame> observer)
        {
            if (observer != null){
                _observers.Remove(observer);
            }
        }

        private static void Notify()
        {
            foreach (IGameObserver<AlurGame> observer in _observers){
                observer.UpdateData(_alurSaatIni);
            }
        }

        public static AlurGame AlurSaatIni
        {
            get { return _alurSaatIni; }
            set
            {
                // PRECONDITION (DbC): Alur baru tidak boleh NULL
                if (value == AlurGame.NULL)
                {
                    throw new ArgumentException("Kontrak Dilanggar: AlurGame tidak boleh diatur ke NULL setelah inisialisasi.");
                }

                if (_alurSaatIni != value)
                {
                    _alurSaatIni = value;
                    Notify();
                }
            }
        }
    }
}