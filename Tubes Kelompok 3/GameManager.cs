using System;
using System.Collections.Generic;
using Tubes_Kelompok_3.Interface;

namespace Tubes_Kelompok_3
{
    public enum AlurGame { NULL, HalamanLogin, HalamanRegistrasi, MAIN_MENU, MENU_PILIH_MODE, MODE_MEMILIH_KATA, MODE_GAMBAR, MODE_MENCOCOKAN_KATA, MODE_GAMBAR_LEVEL1, MODE_GAMBAR_LEVEL2, MODE_GAMBAR_LEVEL3, MODE_MENCOCOKKANKATA_LEVEL1, MODE_MENCOCOKKANKATA_LEVEL2, 
        MODE_MENCOCOKKANKATA_LEVEL3, MODE_MEMILIHKATA_LEVEL1, MODE_MEMILIHKATA_LEVEL2, MODE_MEMILIHKATA_LEVEL3 }
    public sealed class GameManager : ISubject<AlurGame>
    {
        private const string ErrorAlurNull = "Kontrak Dilanggar: AlurGame tidak boleh diatur ke NULL setelah inisialisasi.";
        private const string ErrorObserverNull = "Observer tidak boleh null.";

        private static readonly GameManager _instance = new GameManager();

        private readonly List<IGameObserver<AlurGame>> _observers;
        private AlurGame _alurSaatIni;

        private GameManager()
        {
            _observers = new List<IGameObserver<AlurGame>>();
            _alurSaatIni = AlurGame.NULL;
        }

        public static GameManager Instance
        {
            get { return _instance; }
        }

        public void Attach(IGameObserver<AlurGame> observer)
        {
            // Defensive Programming
            if (observer == null) throw new ArgumentNullException(nameof(observer), ErrorObserverNull);
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void Detach(IGameObserver<AlurGame> observer)
        {
            if (observer != null)
            {
                _observers.Remove(observer);
            }
        }

        public void Notify()
        {
            foreach (IGameObserver<AlurGame> observer in _observers)
            {
                observer.UpdateData(_alurSaatIni);
            }
        }

        public AlurGame AlurSaatIni
        {
            get { return _alurSaatIni; }
            set
            {
                // PRECONDITION (DbC)
                if (value == AlurGame.NULL)
                {
                    throw new ArgumentException(ErrorAlurNull);
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
