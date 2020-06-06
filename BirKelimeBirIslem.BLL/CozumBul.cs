﻿using System;
using System.Collections.Generic;
using System.Text;
using static BirKelimeBirIslem.BLL.Operator;

namespace BirKelimeBirIslem.BLL
{
    public class CozumBul
    {
        public List<int> TumSayilar { get; private set; }

        public int Hdf2 { get; private set; }

        private Islem Islem { get; set; }

        private int enYakin = int.MaxValue;

        public int puan;

        public CozumBul(int _hedef, List<int> _tekbasamakli, int _ikibasamakli)
        {
            TumSayilar = new List<int>();

            this.Hdf2 = _hedef;
            this.TumSayilar.Add(_ikibasamakli);
            this.TumSayilar.AddRange(_tekbasamakli);
            Coz();
        }
        public void Coz()
        {
            for (int i = 0; i < TumSayilar.Count; i++)
            {
                Islem _denklem = new Islem(TumSayilar[i]);
                List<int> arttikliste = KisaListeOlustur(TumSayilar, i);
                if (CozumAra(_denklem, arttikliste))
                    break;
            }
        }

        private List<int> KisaListeOlustur(List<int> _eskiliste, int _sirano)
        {
            List<int> yeniliste = new List<int>();
            for (int i = 0; i < _eskiliste.Count; i++)
                if (i != _sirano)
                    yeniliste.Add(_eskiliste[i]);
            return yeniliste;
        }

        private bool CozumAra(Islem _denklembaslangici, List<int> _artikliste)
        {
            for (int i = 0; i < _artikliste.Count; i++)
            {
                foreach (Operator_List islem in Enum.GetValues(typeof(Operator_List)))
                {
                    List<int> yeniartikliste = KisaListeOlustur(_artikliste, i);
                    int siradakisayi = _artikliste[i];
                    if (CozumeKartiEkle(siradakisayi, islem, _denklembaslangici, yeniartikliste))
                        return true;
                }
            }
            return false;
        }

        private bool CozumeKartiEkle(int _siradakisayi, Operator_List _islem, Islem _denklembaslangici, List<int> _artikliste)
        {
            Islem denklem = new Islem(_denklembaslangici, _islem, _siradakisayi);

            if (Math.Abs(Hdf2 - denklem.DegerHesapla) <= enYakin)
            {
                enYakin = Math.Abs(Hdf2 - denklem.DegerHesapla);
                this.Islem = denklem;
                if (denklem.DegerHesapla == Hdf2) return true;
            }

            if (_artikliste.Count == 0)
            {
                return false;
            }

            return CozumAra(denklem, _artikliste);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Islem.ToString());

            int fark = Math.Abs(this.Islem.DegerHesapla - Hdf2);
            string ifade;
            switch (fark)
            {
                case 0:
                    puan = 10;
                    ifade = "Puan: 10" + Environment.NewLine + "(Tam Sonuç)";
                    break;
                case 1:
                    puan = 9;
                    ifade = "Puan: 9" + Environment.NewLine;
                    break;
                case 2:
                    puan = 8;
                    ifade = "Puan: 8" + Environment.NewLine;
                    break;
                case 3:
                    puan = 7;
                    ifade = "Puan: 7" + Environment.NewLine;
                    break;
                case 4:
                    puan = 6;
                    ifade = "Puan: 6" + Environment.NewLine;
                    break;
                case 5:
                    puan = 5;
                    ifade = "Puan: 5" + Environment.NewLine;
                    break;
                case 6:
                    puan = 4;
                    ifade = "Puan: 4" + Environment.NewLine;
                    break;
                case 7:
                    puan = 3;
                    ifade = "Puan: 3" + Environment.NewLine;
                    break;
                case 8:
                    puan = 2;
                    ifade = "Puan: 2" + Environment.NewLine;
                    break;
                case 9:
                    puan = 1;
                    ifade = "Puan: 1" + Environment.NewLine;
                    break;
                default:
                    puan = 0;
                    ifade = "Puan Alamadınız!" + Environment.NewLine;
                    break;
            }
            sb.Append(Environment.NewLine + ifade);

            return sb.ToString();
        }
    }
}
