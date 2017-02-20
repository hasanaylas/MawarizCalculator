using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MawarizCalculator_Windows
{
    public class MawarizCalculator
    {
        //Mendeklarasikan hartaWarisan dan beberapa harta ahli waris yang memiliki bagian 'ashabah bil ghair
        public double hartaWarisan;

        //Mendeklarasikan 28 ahli waris dalam bentuk variabel boolean
        public bool ayah, kakek, kakekbuyut;
        public bool nenekbuyut_ummAbuAb, nenek_ummAb, nenekbuyut_ummUmmAb;
        public bool ibu, nenek_ummUmm, nenekbuyut_ummUmmUmm;
        public bool anaklaki, cuculaki, cicitlaki;
        public bool anakpr, cucupr, cicitpr;
        public bool sdrKandungLaki, ponakanLaki_ibnuSyaqiq, sdrKandungPr;
        public bool sdrSebapakLaki, ponakanLaki_ibnuAkhiLiAb, sdrSebapakPr, sdrSeibu_LkPr;
        public bool pamanSekandungBapak, sepupuLaki_ibnuAmSyaqiq;
        public bool pamanSebapakBapak, sepupuLaki_ibnuAmLiAb;
        public bool suami, istri;

        public int jumlahAnakLaki, jumlahCucuLaki, jumlahCicitLaki;
        public int jumlahAnakPr, jumlahCucuPr, jumlahCicitPr;
        public int jumlahSdrKndPr, jumlahSdrBpkPr, jumlahSdrSeibu_LkPr;
        public int jumlahSaudaraTotal;

        //Asal masalah-Bagian
        public bool seperDua1_2, seperEmpat1_4, seperDelapan1_8;
        public bool duaPerTiga2_3, seperTiga1_3, seperEnam1_6;
        public int AM, AM_sisa, AMAnakLaki, AMCucuLaki, AMCicitLaki, AMSdrKndLaki, AMSdrBpkLaki;

        //Deklarasi bagian tiap ahli waris menurut sudut pandang Asal Masalah
        public int bagAyah, bagKakek, bagKakekBuyut;
        public int bagNenekbuyut_ummAbuAb, bagNenek_ummAb, bagNenekbuyut_ummUmmAb;
        public int bagIbu, bagNenek_ummUmm, bagNenekbuyut_ummUmmUmm;
        public int bagAnaklaki, bagCuculaki, bagCicitlaki;
        public int bagAnakpr, bagCucupr, bagCicitpr;
        public int bagSdrKandungLaki, bagPonakanLaki_ibnuSyaqiq, bagSdrKandungPr;
        public int bagSdrSebapakLaki, bagPonakanLaki_ibnuAkhiLiAb, bagSdrSebapakPr, bagSdrSeibu_LkPr;
        public int bagPamanSekandungBapak, bagSepupuLaki_ibnuAmSyaqiq;
        public int bagPamanSebapakBapak, bagSepupuLaki_ibnuAmLiAb;
        public int bagSuami, bagIstri;

        //Mencari asal masalah lewat bagian-bagian ahli waris
        public void AsalMasalah()
        {
            if (seperDua1_2 == true && (seperEmpat1_4 && seperDelapan1_8 && duaPerTiga2_3 && seperTiga1_3 && seperEnam1_6 == false))
            {
                AM = 2;
            }
            else if (seperEmpat1_4 == true && (seperDua1_2 && seperDelapan1_8 && duaPerTiga2_3 && seperTiga1_3 && seperEnam1_6 == false))
            {
                AM = 4;
            }
            else if (seperDelapan1_8 == true && (seperDua1_2 && seperEmpat1_4 && duaPerTiga2_3 && seperTiga1_3 && seperEnam1_6 == false))
            {
                AM = 8;
            }
            else if (duaPerTiga2_3 || seperTiga1_3 == true && (seperDua1_2 && seperDelapan1_8 && seperEnam1_6 && seperEmpat1_4 == false))
            {
                AM = 3;
            }
            else if (seperEnam1_6 == true && (seperDua1_2 && seperEmpat1_4 && duaPerTiga2_3 && seperTiga1_3 && seperDelapan1_8 == false))
            {
                AM = 6;
            }
        }

        //Algoritma Ahli Waris
        public double hitungAyah(double harta)
        {
            if (anaklaki || cuculaki || cicitlaki == true)
            {
                seperEnam1_6 = true;        //mengaktifkan asal masalah
                bagAyah = AM / 6;           //memasukkan bagian ayah menurut asal masalah
                harta /= AM;                //mendapatkan satu bagian dari (hartawarisan / asal masalah)
                harta *= bagAyah;           //mendapatkan bagian ayah dari harta warisan
            }
            else if (anakpr || cucupr || cicitpr == true)
            {
                seperEnam1_6 = true;
                AM_sisa = AM - (bagKakek + bagKakekBuyut
                           + bagNenekbuyut_ummAbuAb + bagNenek_ummAb + bagNenekbuyut_ummUmmAb
                           + bagIbu + bagNenek_ummUmm + bagNenekbuyut_ummUmmUmm
                           + bagAnaklaki + bagCuculaki + bagCicitlaki
                           + bagAnakpr + bagCucupr + bagCicitpr
                           + bagSdrKandungLaki + bagPonakanLaki_ibnuSyaqiq + bagSdrKandungPr
                           + bagSdrSebapakLaki + bagPonakanLaki_ibnuAkhiLiAb + bagSdrSebapakPr + bagSdrSeibu_LkPr
                           + bagPamanSekandungBapak + bagSepupuLaki_ibnuAmSyaqiq
                           + bagPamanSebapakBapak + bagSepupuLaki_ibnuAmLiAb
                           + bagSuami + bagIstri);
                bagAyah = AM / 6 + AM_sisa;
                harta /= AM;
                harta *= bagAyah;
            }
            else if (ibu && suami == true)
            {
                seperEnam1_6 = true;
                AM_sisa = AM - (bagKakek + bagKakekBuyut
                           + bagNenekbuyut_ummAbuAb + bagNenek_ummAb + bagNenekbuyut_ummUmmAb
                           + bagIbu + bagNenek_ummUmm + bagNenekbuyut_ummUmmUmm
                           + bagAnaklaki + bagCuculaki + bagCicitlaki
                           + bagAnakpr + bagCucupr + bagCicitpr
                           + bagSdrKandungLaki + bagPonakanLaki_ibnuSyaqiq + bagSdrKandungPr
                           + bagSdrSebapakLaki + bagPonakanLaki_ibnuAkhiLiAb + bagSdrSebapakPr + bagSdrSeibu_LkPr
                           + bagPamanSekandungBapak + bagSepupuLaki_ibnuAmSyaqiq
                           + bagPamanSebapakBapak + bagSepupuLaki_ibnuAmLiAb
                           + bagSuami + bagIstri);
                bagAyah = 2 /3 * AM_sisa;
                harta *= bagAyah;
            }
            else if (ibu && istri == true)
            {

            }
            else
            {
                harta += AM_sisa;
            }
            return harta;
        }

        public double hitungKakek(double harta)
        {
            if (ayah == true)
            {
                harta = 0;
            }
            else if (anaklaki || cuculaki || cicitlaki == true)
            {
               
            }
            else if (anakpr || cucupr || cicitpr == true)
            {

            }
            else if (ibu && suami == true)
            {

            }
            else if (ibu && istri == true)
            {

            }
            else
            {
                harta += AM_sisa;
            }
            return harta;
        }

        public double hitungKakekbuyut(double harta)
        {
            if (kakek == true)
            {
                harta = 0;
            }
            else if (ayah == true)
            {
                harta = 0;
            }
            else if (anaklaki || cuculaki || cicitlaki == true)
            {
                harta *= 1 / 6;
            }
            else if (anakpr || cucupr || cicitpr == true)
            {

            }
            else if (ibu && suami == true)
            {

            }
            else if (ibu && istri == true)
            {

            }
            else
            {
                harta += AM_sisa;
            }
            return harta;
        }

        public double hitungNenekbuyut_ummAbuAb(double harta)
        {
            if (ayah == true)
            {
                harta = 0;
            }
            else if (ibu == true)
            {
                harta = 0;
            }
            else if (kakek == true)
            {
                harta = 0;
            }
            else if (nenek_ummAb == true)
            {
                harta = 0;
            }
            else
            {
                harta *= 1 / 6;
            }
            return harta;
        }

        public double hitungNenek_ummAb(double harta)
        {
            if (ayah == true)
            {
                harta = 0;
            }
            else if (ibu == true)
            {
                harta = 0;
            }
            else
            {
                harta *= 1 / 6;
            }
            return harta;
        }

        public double hitungNenekbuyut_ummUmmAb(double harta)
        {
            if (ayah == true)
            {
                harta = 0;
            }
            else if (ibu == true)
            {
                harta = 0;
            }
            else if (nenek_ummAb == true)
            {
                harta = 0;
            }
            else
            {
                harta *= 1 / 6;
            }
            return harta;
        }

        public double hitungIbu(double harta)
        {
            if (anaklaki || cuculaki || cicitlaki || anakpr || cucupr || cicitpr == true)
            {
                harta *= 1 / 6;
            }
            else if (jumlahSaudaraTotal > 1)
            {
                harta *= 1 / 6;
            }
            else if (ayah && suami == true)
            {
                harta = 1 / 3 * AM_sisa;
            }
            else if (ayah && istri == true)
            {
                harta = 1 / 3 * AM_sisa;
            }
            else
            {
                harta *= 1 / 3;
            }
            return harta;
        }

        public double hitungNenek_ummUmm(double harta)
        {
            if (ibu == true)
            {
                harta = 0;
            }
            else
            {
                harta *= 1 / 6;
            }
            return harta;
        }

        public double hitungNenekbuyut_ummUmmUmm(double harta)
        {
            if (nenek_ummUmm == true)
            {
                harta = 0;
            }
            else if (ibu == true)
            {
                harta = 0;
            }
            else
            {
                harta *= 1 / 6;
            }
            return harta;
        }

        public double hitungAnaklaki(double harta)
        {
            if (anakpr == true)
            {

            }
            else
            {

            }
            return harta;
        }

        public double hitungCuculaki(double harta)
        {
            if (anaklaki == true)
            {
                harta = 0;
            }
            else if (cucupr == true)
            {

            }
            else
            {

            }
            return harta;
        }

        public double hitungCicitlaki(double harta)
        {
            if (cuculaki == true)
            {
                harta = 0;
            }
            else if (anaklaki == true)
            {
                harta = 0;
            }
            else if (cicitpr == true)
            {

            }
            else
            {

            }
            return harta;
        }

        public double hitungAnakpr(double harta)
        {
            if (anaklaki == true)
            {

            }
            else if (jumlahAnakPr >= 1)
            {

            }
            else
            {

            }
            return harta;
        }

        public double hitungCucupr(double harta)
        {
            if (anaklaki == true)
            {
                harta = 0;
            }
            else if (cuculaki == true)
            {

            }
            return harta;
        }

        public double hitungCicitpr(double harta)
        {
            return harta;
        }

        public double hitungSdrKandungLaki(double harta)
        {
            if (anaklaki || cuculaki || cicitlaki == true)
            {
                harta = 0;
            }
            else if (ayah == true)
            {
                harta = 0;
            }
            else if (sdrKandungPr == true)
            {

            }
            else if (ibu && suami && sdrSeibu_LkPr == true)
            {

            }
            else
            {

            }
            return harta;
        }

        public double hitungPonakanLaki_ibnuSyaqiq(double harta)
        {
            if (anaklaki || cuculaki || cicitlaki == true)
            {
                harta = 0;
            }
            else if (ayah || kakek || kakekbuyut == true)
            {
                harta = 0;
            }
            else if (sdrKandungLaki || sdrSebapakLaki == true)
            {
                harta = 0;
            }
            else if (sdrKandungPr && (anakpr || cucupr || cicitpr) == true)
            {
                harta = 0;
            }
            else if (sdrSebapakPr && (anakpr || cucupr || cicitpr) == true)
            {
                harta = 0;
            }
            else
            {

            }
            return harta;
        }

        public double hitungSdrKandungPr(double harta)
        {
            if (anaklaki || cuculaki || cicitlaki == true)
            {
                harta = 0;
            }
            else if (ayah == true)
            {
                harta = 0;
            }
            else if (anakpr || cucupr || cicitpr == true)
            {

            }
            else if (sdrKandungLaki == true)
            {

            }
            else if (jumlahSdrKndPr > 1)
            {

            }
            else
            {

            }
            return harta;
        }

        public double hitungSdrSebapakLaki(double harta)
        {
            if (anaklaki || cuculaki || cicitlaki == true)
            {
                harta = 0;
            }
            else if (ayah == true)
            {
                harta = 0;
            }
            else if (sdrKandungLaki == true)
            {
                harta = 0;
            }
            else if (sdrKandungPr && (anakpr || cucupr || cicitpr) == true)
            {
                harta = 0;
            }
            else if (sdrSebapakPr == true)
            {

            }
            else
            {

            }
            return harta;
        }

        public double hitungPonakanLaki_ibnuAkhiLiAb(double harta)
        {
            if (anaklaki || cuculaki || cicitlaki == true)
            {
                harta = 0;
            }
            else if (ayah || kakek || kakekbuyut == true)
            {
                harta = 0;
            }
            else if ((sdrKandungPr || sdrSebapakPr) && (anakpr || cucupr || cicitpr) == true)
            {
                harta = 0;
            }
            else if (sdrKandungLaki || sdrSebapakLaki == true)
            {
                harta = 0;
            }
            else if (ponakanLaki_ibnuSyaqiq == true)
            {
                harta = 0;
            }
            else
            {

            }
            return harta;
        }

        public double hitungSdrSebapakPr(double harta)
        {
            if (sdrKandungLaki == true)
            {
                harta = 0;
            }
            else if (anaklaki || cuculaki || cicitlaki == true)
            {
                harta = 0;
            }
            else if (sdrKandungPr && (anakpr || cucupr || cicitpr) == true)
            {
                harta = 0;
            }
            else if (sdrSebapakLaki == true)
            {

            }
            else if (sdrKandungPr == true)
            {

            }
            else if (anakpr || cucupr || cicitpr == true)
            {

            }
            else if (jumlahSdrBpkPr >= 1)
            {

            }
            else
            {

            }
            return harta;
        }

        public double hitungSdrSeibu_LkPr(double harta)
        {
            if (ayah || kakek || kakekbuyut == true)
            {
                harta = 0;
            }
            else if (anaklaki || cuculaki || cicitlaki == true)
            {
                harta = 0;
            }
            else if (anakpr || cucupr || cicitpr == true)
            {
                harta = 0;
            }
            else if (jumlahSdrSeibu_LkPr >= 1)
            {

            }
            else if (ibu && suami && sdrKandungLaki == true)
            {

            }
            return harta;
        }

        public double hitungPamanSekandungBapak(double harta)
        {
            if (anaklaki && cuculaki && cicitlaki == true)
            {
                harta = 0;
            }
            else if (sdrKandungLaki || sdrSebapakLaki == true)
            {
                harta = 0;
            }
            else if (ayah || kakek || kakekbuyut == true)
            {
                harta = 0;
            }
            else if (ponakanLaki_ibnuAkhiLiAb || ponakanLaki_ibnuSyaqiq == true)
            {
                harta = 0;
            }
            else if ((sdrKandungPr || sdrSebapakPr) && (anakpr || cucupr || cicitpr) == true)
            {

            }
            else
            {

            }
            return harta;
        }

        public double hitungSepupuLaki_ibnuAmSyaqiq(double harta)
        {
            if (pamanSebapakBapak == true)
            {
                harta = 0;
            }
            else if (pamanSekandungBapak == true)
            {
                harta = 0;
            }
            else if (anaklaki || cuculaki || cicitlaki == true)
            {
                harta = 0;
            }
            else if (sdrKandungLaki || sdrSebapakLaki == true)
            {
                harta = 0;
            }
            else if (ayah || kakek || kakekbuyut == true)
            {
                harta = 0;
            }
            else if (ponakanLaki_ibnuAkhiLiAb || ponakanLaki_ibnuSyaqiq == true)
            {
                harta = 0;
            }
            else if ((sdrKandungPr || sdrSebapakPr) && (anakpr || cucupr || cicitpr) == true)
            {
                harta = 0;
            }
            else
            {

            }
            return harta;
        }

        public double hitungPamanSebapakBapak(double harta)
        {
            if (pamanSekandungBapak == true)
            {
                harta = 0;
            }
            else if (anaklaki && cuculaki && cicitlaki == true)
            {
                harta = 0;
            }
            else if (sdrKandungLaki || sdrSebapakLaki == true)
            {
                harta = 0;
            }
            else if (ayah || kakek || kakekbuyut == true)
            {
                harta = 0;
            }
            else if (ponakanLaki_ibnuAkhiLiAb || ponakanLaki_ibnuSyaqiq == true)
            {
                harta = 0;
            }
            else if ((sdrKandungPr || sdrSebapakPr) && (anakpr || cucupr || cicitpr) == true)
            {

            }
            else
            {

            }
            return harta;
        }

        public double hitungSepupuLaki_ibnuAmLiAb(double harta)
        {
            if (pamanSebapakBapak == true)
            {
                harta = 0;
            }
            else if (pamanSekandungBapak == true)
            {
                harta = 0;
            }
            else if (sepupuLaki_ibnuAmSyaqiq == true)
            {
                harta = 0;
            }
            else if (anaklaki || cuculaki || cicitlaki == true)
            {
                harta = 0;
            }
            else if (sdrKandungLaki || sdrSebapakLaki == true)
            {
                harta = 0;
            }
            else if (ayah || kakek || kakekbuyut == true)
            {
                harta = 0;
            }
            else if (ponakanLaki_ibnuAkhiLiAb || ponakanLaki_ibnuSyaqiq == true)
            {
                harta = 0;
            }
            else if ((sdrKandungPr || sdrSebapakPr) && (anakpr || cucupr || cicitpr) == true)
            {

            }
            else
            {

            }
            return harta;
        }

        public double hitungSuami(double harta)
        {
            if (anaklaki || cuculaki || cicitlaki || anakpr || cucupr || cicitpr == true)
            {

            }
            else
            {

            }
            return harta;
        }

        public double hitungIstri(double harta)
        {
            if (anaklaki || cuculaki || cicitlaki || anakpr || cucupr || cicitpr == true)
            {

            }
            else
            {

            }
            return harta;
        }


        //Algoritma keterangan Ahli Waris
        public string ketAyah(string keterangan)
        {
            if (anaklaki == true)
            {
                keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena mayit meninggalkan" +
                             "ahli waris anak laki-laki";
            }
            else if (cuculaki == true)
            {
                keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena mayit meninggalkan" +
                             "ahli waris cucu laki-laki";
            }
            else if (cicitlaki == true)
            {
                keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena mayit meninggalkan" +
                             "ahli waris cicit laki-laki";
            }
            else if (anakpr == true)
            {
                keterangan = "Mendapatkan bagian 1/6 + Sisa dari harta warisan karena mayit" +
                             "meninggalkan ahli waris anak perempuan";
            }
            else if (cucupr == true)
            {
                keterangan = "Mendapatkan bagian 1/6 + Sisa dari harta warisan karena mayit" +
                             "meninggalkan ahli waris cucu perempuan";
            }
            else if (cicitpr == true)
            {
                keterangan = "Mendapatkan bagian 1/6 + Sisa dari harta warisan karena mayit" +
                             "meninggalkan ahli waris cicit perempuan";
            }
            else
            {
                keterangan = "Mendapatkan bagian Sisa karena mayit tidak meninggalkan" +
                             "ahli waris dari jalur anak sama sekali";
            }
            return keterangan;
        }

        public string ketKakek(string keterangan)
        {
            if (ayah == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris Ayah";
            }
            else if (anaklaki == true)
            {
                keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena mayit meninggalkan" +
                             "ahli waris anak laki-laki";
            }
            else if (cuculaki == true)
            {
                keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena mayit meninggalkan" +
                             "ahli waris cucu laki-laki";
            }
            else if (cicitlaki == true)
            {
                keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena mayit meninggalkan" +
                             "ahli waris cicit laki-laki";
            }
            else if (anakpr == true)
            {
                keterangan = "Mendapatkan bagian 1/6 + Sisa dari harta warisan karena mayit" +
                             "meninggalkan ahli waris anak perempuan";
            }
            else if (cucupr == true)
            {
                keterangan = "Mendapatkan bagian 1/6 + Sisa dari harta warisan karena mayit" +
                             "meninggalkan ahli waris cucu perempuan";
            }
            else if (cicitpr == true)
            {
                keterangan = "Mendapatkan bagian 1/6 + Sisa dari harta warisan karena mayit" +
                             "meninggalkan ahli waris cicit perempuan";
            }
            else
            {
                keterangan = "Mendapatkan bagian Sisa karena mayit tidak meninggalkan" +
                             "ahli waris dari jalur anak sama sekali";
            }
            return keterangan;
        }

        public string ketKakekbuyut(string keterangan)
        {
            if (kakek == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris Kakek";
            }
            else if (ayah == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris Ayah";
            }
            else if (anaklaki == true)
            {
                keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena mayit meninggalkan" +
                             "ahli waris anak laki-laki";
            }
            else if (cuculaki == true)
            {
                keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena mayit meninggalkan" +
                             "ahli waris cucu laki-laki";
            }
            else if (cicitlaki == true)
            {
                keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena mayit meninggalkan" +
                             "ahli waris cicit laki-laki";
            }
            else if (anakpr == true)
            {
                keterangan = "Mendapatkan bagian 1/6 + Sisa dari harta warisan karena mayit" +
                             "meninggalkan ahli waris anak perempuan";
            }
            else if (cucupr == true)
            {
                keterangan = "Mendapatkan bagian 1/6 + Sisa dari harta warisan karena mayit" +
                             "meninggalkan ahli waris cucu perempuan";
            }
            else if (cicitpr == true)
            {
                keterangan = "Mendapatkan bagian 1/6 + Sisa dari harta warisan karena mayit" +
                             "meninggalkan ahli waris cicit perempuan";
            }
            else
            {
                keterangan = "Mendapatkan bagian Sisa karena mayit tidak meninggalkan" +
                             "ahli waris dari jalur anak sama sekali";
            }
            return keterangan;
        }

        public string ketNenekbuyut_UmmAbuAb(string keterangan)
        {
            if (ayah == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris Ayah";
            }
            else if (ibu == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris Ibu";
            }
            else if (kakek == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris Kakek";
            }
            else if (nenek_ummAb == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris Nenek (ummAb)";
            }
            else
            {
                keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena mayit tidak meninggalkan" +
                             "ahli waris berupa ayah, kakek, ibu, dan nenek (ummAb)";
            }
            return keterangan;
        }

        public string ketNenek_ummAb(string keterangan)
        {
            if (ayah == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris Ayah";
            }
            else if (ibu == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris Ibu";
            }
            else
            {
                keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena mayit tidak meninggalkan" +
                             "ahli waris berupa ayah atau ibu";
            }
            return keterangan;
        }

        public string ketNenekbuyut_ummUmmAb(string keterangan)
        {
            if (ayah == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris Ayah";
            }
            else if (ibu == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris Ibu";
            }
            else if (nenek_ummAb == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris Nenek (ummAb)";
            }
            else
            {
                keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena mayit tidak meninggalkan" +
                             "ahli waris berupa ayah, ibu, dan nenek (ummAb)";
            }
            return keterangan;
        }

        public string ketIbu(string keterangan)
        {
            if (anaklaki == true)
            {
                keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena mayit meninggalkan" +
                             "ahli waris anak laki-laki";
            }
            else if (cuculaki == true)
            {
                keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena mayit meninggalkan" +
                             "ahli waris cucu laki-laki";
            }
            else if (cicitlaki == true)
            {
                keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena mayit meninggalkan" +
                             "ahli waris cicit laki-laki";
            }
            else if (anakpr == true)
            {
                keterangan = "Mendapatkan bagian 1/6 + Sisa dari harta warisan karena mayit" +
                             "meninggalkan ahli waris anak perempuan";
            }
            else if (cucupr == true)
            {
                keterangan = "Mendapatkan bagian 1/6 + Sisa dari harta warisan karena mayit" +
                             "meninggalkan ahli waris cucu perempuan";
            }
            else if (cicitpr == true)
            {
                keterangan = "Mendapatkan bagian 1/6 + Sisa dari harta warisan karena mayit" +
                             "meninggalkan ahli waris cicit perempuan";
            }
            else if (jumlahSaudaraTotal > 1)
            {
                keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena mayit" +
                             "meninggalkan ahli waris dua saudara atau lebih";
            }
            else if (ayah && suami == true)
            {
                keterangan = "Mendapatkan bagian 1/3 Sisa dari harta warisan karena" +
                             "mayit meninggalkan ahli waris berupa ayah bersama suami";
            }
            else if (ayah && istri == true)
            {
                keterangan = "Mendapatkan bagian 1/3 Sisa dari harta warisan karena" +
                             "mayit meninggalkan ahli waris berupa ayah bersama istri";
            }
            return keterangan;
        }

        public string ketNenek_ummUmm(string keterangan)
        {
            if (ibu == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris Ibu";
            }
            else
            {
                keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena mayit tidak meninggalkan" +
                             "ahli waris ibu";
            }
            return keterangan;
        }

        public string ketNenekbuyut_ummUmmUmm(string keterangan)
        {
            if (nenek_ummUmm == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris Nenek (ummUmm)";
            }
            else if (ibu == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris Ibu";
            }
            else
            {
                keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena mayit tidak meninggalkan" +
                             "ahli waris berupa ibu atau Nenek (ummUmm)";
            }
            return keterangan;
        }

        public string ketAnaklaki(string keterangan)
        {
            if (anakpr == true)
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah bil ghair) dari harta warisan" +
                             "karena mayit meninggalkan ahli waris anak perempuan";
            }
            else
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah bin nafsi) dari harta warisan" +
                             "karena mayit tidak meninggalkan ahli waris anak perempuan";
            }
            return keterangan;
        }

        public string ketCuculaki(string keterangan)
        {
            if (anaklaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris anak laki-laki";
            }
            else if (cucupr == true)
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah bil ghair) dari harta warisan" +
                             "karena mayit meninggalkan ahli waris cucu perempuan";
            }
            else
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah bin nafsi) dari harta warisan" +
                             "karena mayit tidak meninggalkan ahli waris cucu perempuan";
            }
            return keterangan;
        }

        public string ketCicitlaki(string keterangan)
        {
            if (cuculaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris cucu laki-laki";
            }
            else if (anaklaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris anak laki-laki";
            }
            else if (cicitpr == true)
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah bil ghair) dari harta warisan" +
                             "karena mayit meninggalkan ahli waris cicit perempuan";
            }
            else
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah bin nafsi) dari harta warisan" +
                             "karena mayit tidak meninggalkan ahli waris cicit perempuan";
            }
            return keterangan;
        }

        public string ketAnakpr(string keterangan)
        {
            if (anaklaki == true)
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah bil ghair) dari harta warisan" +
                             "karena mayit meninggalkan ahli waris anak laki-laki";
            }
            else if (jumlahAnakPr > 1)
            {
                keterangan = "Mendapatkan bagian 2/3 dari harta warisan karena terdapat dua orang" +
                             "atau lebih dan mayit tidak meninggalkan ahli waris berupa anak laki-laki";
            }
            else
            {
                keterangan = "Mendapatkan bagian 1/2 dari harta warisan karena hanya seorang dan" +
                             "mayit tidak meninggalkan ahli waris berupa anak laki-laki.";
            }
            return keterangan;
        }

        public string ketCucupr(string keterangan)
        {
            if (anaklaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa anak laki-laki";
            }
            else if (cuculaki == true)
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah bil ghair) dari harta warisan karena" +
                             "terdapat cucu laki-laki dan mayit tidak meninggalkan ahli waris berupa anak laki-laki";
            }
            else if (anakpr == true)
            {
                if (jumlahAnakPr > 1)
                {
                    keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris" +
                                 "berupa dua anak perempuan atau lebih tanpa bersama cucu laki-laki";
                }
                else
                {
                    keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena terdapat seorang" +
                                 "anak perempuan dan mayit tidak meninggalkan ahli waris berupa anak atau cucu laki-laki";
                }
            }
            else if (jumlahCucuPr > 1)
            {
                keterangan = "Mendapatkan bagian 2/3 dari harta warisan karena terdapat dua orang atau" +
                             "lebih dan mayit tidak meninggalkan ahli waris berupa anak laki-laki";
            }
            else
            {
                keterangan = "Mendapatkan bagian 1/2 dari harta warisan karena hanya seorang dan mayit" +
                             "tidak meninggalkan ahli waris berupa anak laki-laki";
            }
            return keterangan;
        }

        public string ketCicitpr(string keterangan)
        {
            if (anaklaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa anak laki-laki";
            }
            else if (cuculaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cucu laki-laki";
            }
            else if (cicitlaki == true)
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah bil ghair) dari harta warisan" +
                             "karena terdapat cicit laki-laki dan mayit tidak meninggalkan ahli waris berupa anak atau cucu laki-laki";
            }
            else if (cucupr == true)
            {
                if (jumlahAnakPr > 1)
                {
                    keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris" +
                                 "berupa dua cucu perempuan atau lebih tanpa bersama cicit laki-laki";
                }
                else
                {
                    keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena terdapat seorang" +
                                 "cucu perempuan dan mayit tidak meninggalkan ahli waris berupa anak atau cicit laki-laki";
                }
            }
            else if (anakpr == true)
            {
                if (jumlahAnakPr > 1)
                {
                    keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris" +
                                 "berupa dua anak perempuan atau lebih tanpa bersama cicit laki-laki";
                }
                else
                {
                    keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena terdapat seorang" +
                                 "anak perempuan dan mayit tidak meninggalkan ahli waris berupa anak atau cicit laki-laki";
                }
            }
            else if (jumlahCicitPr > 1)
            {
                keterangan = "Mendapatkan bagian 2/3 dari harta warisan karena terdapat dua orang atau" +
                             "lebih dan mayit tidak meninggalkan ahli waris berupa anak atau cicit laki-laki";
            }
            else
            {
                keterangan = "Mendapatkan bagian 1/2 dari harta warisan karena hanya seorang dan mayit" +
                             "tidak meninggalkan ahli waris berupa anak dan cicit laki-laki";
            }
            return keterangan;
        }

        public string ketSdrKandungLaki(string keterangan)
        {
            if (anaklaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa anak laki-laki";
            }
            else if (cuculaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cucu laki-laki";
            }
            else if (cicitlaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cicit laki-laki";
            }
            else if (ayah == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris ayah";
            }
            else if (sdrKandungPr == true)
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah bil ghair) dari harta warisan karena terdapat" +
                             "saudara perempuan sekandung dan mayit tidak meninggalkan ahli waris berupa ayah, anak, cucu, dan cicit laki-laki";
            }
            else
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah bin nafsi) dari harta warisan karena mayit tidak" +
                             "meninggalkan ahli waris berupa ayah, anak, cucu, dan cicit laki-laki";
            }
            return keterangan;
        }

        public string ketPonakanLaki_ibnuSyaqiq(string keterangan)
        {
            if (anaklaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa anak laki-laki";
            }
            else if (cuculaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cucu laki-laki";
            }
            else if (cicitlaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cicit laki-laki";
            }
            else if (ayah == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris ayah";
            }
            else if (kakek == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris kakek";
            }
            else if (kakekbuyut == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris kakek buyut";
            }
            else if (sdrKandungLaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris saudara laki-laki sekandung";
            }
            else if (sdrSebapakPr == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris saudara laki-laki sebapak";
            }
            else if (sdrKandungPr && (anakpr || cicitpr || cucupr) == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris saudara perempuan sekandung bersama dengan anak/cucu/cicit perempuan";
            }
            else if (sdrSebapakPr && (anakpr || cicitpr || cucupr) == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris saudara perempuan sebapak bersama dengan anak/cucu/cicit perempuan";
            }
            else
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah bin nafsi) dari harta warisan karena mayit tidak " +
                             "meninggalkan ahli waris berupa saudara laki-laki sekandung/sebapak, ayah, anak, cucu, " +
                             "dan cicit laki-laki ataupun saudara perempuan sekandung/sebapak bersama dengan anak, cucu, dan cicit perempuan";
            }
            return keterangan;
        }

        public string ketSdrKandungPr(string keterangan)
        {
            if (ayah == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris ayah";
            }
            else if (anaklaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa anak laki-laki";
            }
            else if (cuculaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cucu laki-laki";
            }
            else if (cicitlaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cicit laki-laki";
            }
            else if (anakpr == true)
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah ma’al ghair) dari harta" +
                             "warisan karena mayit meninggalkan ahli waris anak perempuan";
            }
            else if (cucupr == true)
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah ma’al ghair) dari harta" +
                             "warisan karena mayit meninggalkan ahli waris cucu perempuan";
            }
            else if (cicitpr == true)
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah ma’al ghair) dari harta" +
                             "warisan karena mayit meninggalkan ahli waris cicit perempuan";
            }
            else if (sdrKandungLaki == true)
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah bil ghair) dari harta " +
                             "warisan karena mayit meninggalkan ahli waris saudara kandung laki-laki";
            }
            else if (jumlahSdrKndPr > 1)
            {
                keterangan = "Mendapatkan bagian 2/3 dari harta warisan karena terdapat dua orang " +
                             "atau lebih dan mayit tidak meninggalkan ahli waris berupa ayah, anak, cucu, dan cicit laki-laki";
            }
            else
            {
                keterangan = "Mendapatkan bagian 1/2 dari harta warisan karena hanya seorang dan mayit " +
                             "tidak meninggalkan ahli waris berupa ayah, anak, cucu, dan cicit laki-laki";
            }
            return keterangan;
        }

        public string ketSdrSebapakLaki(string keterangan)
        {
            if (anaklaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa anak laki-laki";
            }
            else if (cuculaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cucu laki-laki";
            }
            else if (cicitlaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cicit laki-laki";
            }
            else if (ayah == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris ayah";
            }
            else if (sdrKandungLaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan " +
                             "ahli waris saudara kandung laki-laki";
            }
            else if (sdrKandungPr && (anakpr || cicitpr || cucupr) == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris saudara perempuan sekandung bersama dengan anak/cucu/cicit perempuan";
            }
            else if (sdrSebapakPr == true)
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah bil ghair) dari harta " +
                             "warisan karena terdapat saudara perempuan sebapak";
            }
            else
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah bin nafsi) dari harta warisan karena mayit tidak " +
                             "meninggalkan ahli waris berupa saudara kandung laki-laki, ayah, anak, cucu, dan cicit " +
                             "laki-laki  ataupun tidak ada saudara perempuan sekandung bersama dengan anak, cucu, dan cicit perempuan";
            }
            return keterangan;
        }

        public string ketPonakanLaki_ibnuAkhiLiAb(string keterangan)
        {
            if (anaklaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa anak laki-laki";
            }
            else if (cuculaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cucu laki-laki";
            }
            else if (cicitlaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cicit laki-laki";
            }
            else if (sdrKandungPr && (anakpr || cicitpr || cucupr) == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris saudara perempuan sekandung bersama dengan anak/cucu/cicit perempuan";
            }
            else if (sdrSebapakPr && (anakpr || cicitpr || cucupr) == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris saudara perempuan sebapak bersama dengan anak/cucu/cicit perempuan";
            }
            else if (ayah == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris ayah";
            }
            else if (kakek == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris kakek";
            }
            else if (kakekbuyut == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris kakek buyut";
            }
            else if (sdrKandungLaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris saudara laki-laki sekandung";
            }
            else if (sdrSebapakLaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris saudara laki-laki sebapak";
            }
            else if (ponakanLaki_ibnuSyaqiq == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris keponakan laki-laki sekandung (IbnuSyaqiq)";
            }
            else
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah bin nafsi) dari harta warisan karena mayit tidak meninggalkan " +
                             "ahli waris berupa keponakan laki-laki sekandung, saudara laki-laki sekandung/sebapak, ayah, anak, " +
                             "cucu, dan cicit laki-laki ataupun saudara perempuan sekandung/sebapak bersama dengan anak, cucu, dan cicit perempuan.";
            }
            return keterangan;
        }

        public string ketSdrSebapakPr(string keterangan)
        {
            if (sdrKandungLaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris saudara laki-laki sekandung";
            }
            else if (anaklaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa anak laki-laki";
            }
            else if (cuculaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cucu laki-laki";
            }
            else if (cicitlaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cicit laki-laki";
            }
            else if (sdrKandungPr && (anakpr || cicitpr || cucupr) == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris saudara perempuan sekandung bersama dengan anak/cucu/cicit perempuan";
            }
            else if (sdrSebapakLaki == true)
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah bil ghair) dari harta warisan karena mayit meninggalkan ahli waris saudara laki-laki sebapak.";
            }
            else if (sdrKandungPr == true)
            {
                keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena terdapat saudara perempuan sekandung yang tidak " +
                             "bersama anak, cucu, atau cicit perempuan dan mayit tidak meninggalkan ahli waris berupa saudara laki-laki " +
                             "sekandung, ayah (ke atas), anak, cucu, dan cicit laki-laki";
            }
            else if (anakpr == true)
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah ma’al ghair) dari harta" +
                             "warisan karena mayit meninggalkan ahli waris anak perempuan";
            }
            else if (cucupr == true)
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah ma’al ghair) dari harta" +
                             "warisan karena mayit meninggalkan ahli waris cucu perempuan";
            }
            else if (cicitpr == true)
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah ma’al ghair) dari harta" +
                             "warisan karena mayit meninggalkan ahli waris cicit perempuan";
            }
            else if (jumlahSdrBpkPr > 1)
            {
                keterangan = "Mendapatkan bagian 2/3 dari harta warisan karena terdapat dua orang atau lebih dan " +
                             "mayit tidak meninggalkan ahli waris berupa saudara laki-laki sekandung, ayah (ke atas), anak, cucu, dan cicit laki-laki";
            }
            else
            {
                keterangan = "Mendapatkan bagian 1/2 dari harta warisan karena hanya seorang dan mayit tidak " +
                             "meninggalkan ahli waris berupa saudara laki-laki sekandung, ayah (ke atas), anak, cucu, dan cicit laki-laki";
            }
            return keterangan;
        }

        public string ketSdrSeibu_LkPr(string keterangan)
        {
            if (ayah == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris ayah";
            }
            else if (kakek == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris kakek";
            }
            else if (kakekbuyut == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris kakek buyut";
            }
            else if (anaklaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa anak laki-laki";
            }
            else if (cuculaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cucu laki-laki";
            }
            else if (cicitlaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cicit laki-laki";
            }
            else if (anakpr == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa anak perempuan";
            }
            else if (cucupr == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cucu perempuan";
            }
            else if (cicitpr == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cicit perempuan";
            }
            else if (jumlahSdrSeibu_LkPr > 1)
            {
                keterangan = "Mendapatkan bagian 1/3 dari harta warisan karena terdapat dua orang atau lebih dan mayit " +
                             "tidak meninggalkan ahli waris berupa ayah (ke atas), anak, cucu, dan cicit laki-laki ataupun perempuan";
            }
            else
            {
                keterangan = "Mendapatkan bagian 1/6 dari harta warisan karena hanya seorang dan mayit tidak meninggalkan " +
                             "ahli waris berupa ayah (ke atas), anak, cucu, dan cicit laki-laki ataupun perempuan";
            }
            return keterangan;
        }

        public string ketPamanSekandungBapak(string keterangan)
        {
            if (anaklaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa anak laki-laki";
            }
            else if (cuculaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cucu laki-laki";
            }
            else if (cicitlaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cicit laki-laki";
            }
            else if (sdrKandungLaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris saudara laki-laki sekandung";
            }
            else if (sdrSebapakLaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris saudara laki-laki sebapak";
            }
            else if (ayah == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris ayah";
            }
            else if (kakek == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris kakek";
            }
            else if (kakekbuyut == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris kakek buyut";
            }
            else if (ponakanLaki_ibnuSyaqiq == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris keponakan laki-laki sekandung (IbnuSyaqiq)";
            }
            else if (ponakanLaki_ibnuAkhiLiAb == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris keponakan laki-laki sekandung (IbnuAmLiAb)";
            }
            else if (sdrKandungPr && (anakpr || cicitpr || cucupr) == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris saudara perempuan sekandung bersama dengan anak/cucu/cicit perempuan";
            }
            else if (sdrSebapakPr && (anakpr || cicitpr || cucupr) == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris saudara perempuan sebapak bersama dengan anak/cucu/cicit perempuan";
            }
            else
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah bin nafsi) dari harta warisan karena mayit tidak meninggalkan " +
                             "ahli waris berupa ayah (ke atas), anak, cucu, dan cicit laki-laki, saudara laki-laki sekandung/sebapak " +
                             "(termasuk keponakan laki-laki sekandung/sebapak) ataupun saudara perempuan sekandung/sebapak bersama dengan anak/cucu/cicit perempuan";
            }
            return keterangan;
        }

        public string ketSepupuLaki_ibnuAmSyaqiq(string keterangan)
        {
            if (pamanSekandungBapak == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris paman (sekandung dengan bapak)";
            }
            else if (pamanSebapakBapak == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris paman (sebapak dengan bapak)";
            }
            else if (anaklaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa anak laki-laki";
            }
            else if (cuculaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cucu laki-laki";
            }
            else if (cicitlaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cicit laki-laki";
            }
            else if (sdrKandungLaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris saudara laki-laki sekandung";
            }
            else if (sdrSebapakLaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris saudara laki-laki sebapak";
            }
            else if (ayah == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris ayah";
            }
            else if (kakek == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris kakek";
            }
            else if (kakekbuyut == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris kakek buyut";
            }
            else if (ponakanLaki_ibnuSyaqiq == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris keponakan laki-laki sekandung (IbnuSyaqiq)";
            }
            else if (ponakanLaki_ibnuAkhiLiAb == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris keponakan laki-laki sekandung (IbnuAmLiAb)";
            }
            else if (sdrKandungPr && (anakpr || cicitpr || cucupr) == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris saudara perempuan sekandung bersama dengan anak/cucu/cicit perempuan";
            }
            else if (sdrSebapakPr && (anakpr || cicitpr || cucupr) == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris saudara perempuan sebapak bersama dengan anak/cucu/cicit perempuan";
            }
            else
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah bin nafsi) dari harta warisan karena mayit tidak meninggalkan " +
                             "ahli waris berupa ayah (ke atas), anak, cucu, dan cicit laki-laki, saudara laki-laki sekandung/sebapak " +
                             "(termasuk keponakan laki-laki sekandung/sebapak) ataupun saudara perempuan sekandung/sebapak bersama dengan anak/cucu/cicit perempuan";
            }
            return keterangan;
        }

        public string ketPamanSebapakBapak(string keterangan)
        {
            if (pamanSekandungBapak == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris paman (sekandung dengan bapak)";
            }
            else if (anaklaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa anak laki-laki";
            }
            else if (cuculaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cucu laki-laki";
            }
            else if (cicitlaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cicit laki-laki";
            }
            else if (sdrKandungLaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris saudara laki-laki sekandung";
            }
            else if (sdrSebapakLaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris saudara laki-laki sebapak";
            }
            else if (ayah == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris ayah";
            }
            else if (kakek == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris kakek";
            }
            else if (kakekbuyut == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris kakek buyut";
            }
            else if (ponakanLaki_ibnuSyaqiq == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris keponakan laki-laki sekandung (IbnuSyaqiq)";
            }
            else if (ponakanLaki_ibnuAkhiLiAb == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris keponakan laki-laki sekandung (IbnuAmLiAb)";
            }
            else if (sdrKandungPr && (anakpr || cicitpr || cucupr) == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris saudara perempuan sekandung bersama dengan anak/cucu/cicit perempuan";
            }
            else if (sdrSebapakPr && (anakpr || cicitpr || cucupr) == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris saudara perempuan sebapak bersama dengan anak/cucu/cicit perempuan";
            }
            else
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah bin nafsi) dari harta warisan karena mayit tidak meninggalkan " +
                             "ahli waris berupa ayah (ke atas), anak, cucu, dan cicit laki-laki, saudara laki-laki sekandung/sebapak " +
                             "(termasuk keponakan laki-laki sekandung/sebapak) ataupun saudara perempuan sekandung/sebapak bersama dengan anak/cucu/cicit perempuan";
            }
            return keterangan;
        }

        public string ketSepupuLaki_ibnuAmLiAb(string keterangan)
        {
            if (sepupuLaki_ibnuAmSyaqiq == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris sepupu laki-laki sekandung (IbnuAmSyaqiq)";
            }
            else if (pamanSekandungBapak == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris paman (sekandung dengan bapak)";
            }
            else if (pamanSebapakBapak == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris paman (sebapak dengan bapak)";
            }
            else if (anaklaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa anak laki-laki";
            }
            else if (cuculaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cucu laki-laki";
            }
            else if (cicitlaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris berupa cicit laki-laki";
            }
            else if (sdrKandungLaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris saudara laki-laki sekandung";
            }
            else if (sdrSebapakLaki == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris saudara laki-laki sebapak";
            }
            else if (ayah == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris ayah";
            }
            else if (kakek == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris kakek";
            }
            else if (kakekbuyut == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris kakek buyut";
            }
            else if (ponakanLaki_ibnuSyaqiq == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris keponakan laki-laki sekandung (IbnuSyaqiq)";
            }
            else if (ponakanLaki_ibnuAkhiLiAb == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan ahli waris keponakan laki-laki sekandung (IbnuAmLiAb)";
            }
            else if (sdrKandungPr && (anakpr || cicitpr || cucupr) == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris saudara perempuan sekandung bersama dengan anak/cucu/cicit perempuan";
            }
            else if (sdrSebapakPr && (anakpr || cicitpr || cucupr) == true)
            {
                keterangan = "Terhalang dari harta warisan karena mayit meninggalkan" +
                             "ahli waris saudara perempuan sebapak bersama dengan anak/cucu/cicit perempuan";
            }
            else
            {
                keterangan = "Mendapatkan bagian Sisa (‘ashobah bin nafsi) dari harta warisan karena mayit tidak meninggalkan " +
                             "ahli waris berupa ayah (ke atas), anak, cucu, dan cicit laki-laki, saudara laki-laki sekandung/sebapak " +
                             "(termasuk keponakan laki-laki sekandung/sebapak) ataupun saudara perempuan sekandung/sebapak bersama dengan anak/cucu/cicit perempuan";
            }
            return keterangan;
        }

        public string ketSuami(string keterangan)
        {
            if (anaklaki == true)
            {
                keterangan = "Mendapatkan bagian 1/4 dari harta warisan karena mayit meninggalkan anak laki-laki";
            }
            else if (cuculaki == true)
            {
                keterangan = "Mendapatkan bagian 1/4 dari harta warisan karena mayit meninggalkan cucu laki-laki";
            }
            else if (cicitlaki == true)
            {
                keterangan = "Mendapatkan bagian 1/4 dari harta warisan karena mayit meninggalkan cicit laki-laki";
            }
            else if (anakpr == true)
            {
                keterangan = "Mendapatkan bagian 1/4 dari harta warisan karena mayit meninggalkan anak perempuan";
            }
            else if (cucupr == true)
            {
                keterangan = "Mendapatkan bagian 1/4 dari harta warisan karena mayit meninggalkan cucu perempuan";
            }
            else if (cicitpr == true)
            {
                keterangan = "Mendapatkan bagian 1/4 dari harta warisan karena mayit meninggalkan cicit perempuan";
            }
            else
            {
                keterangan = "Mendapatkan bagian 1/2 dari harta warisan karena mayit meninggalkan anak/cucu/cicit (laki-laki atau perempuan)";
            }
            return keterangan;
        }

        public string ketIstri(string keterangan)
        {
            if (anaklaki == true)
            {
                keterangan = "Mendapatkan bagian 1/8 dari harta warisan karena mayit meninggalkan anak laki-laki";
            }
            else if (cuculaki == true)
            {
                keterangan = "Mendapatkan bagian 1/8 dari harta warisan karena mayit meninggalkan cucu laki-laki";
            }
            else if (cicitlaki == true)
            {
                keterangan = "Mendapatkan bagian 1/8 dari harta warisan karena mayit meninggalkan cicit laki-laki";
            }
            else if (anakpr == true)
            {
                keterangan = "Mendapatkan bagian 1/8 dari harta warisan karena mayit meninggalkan anak perempuan";
            }
            else if (cucupr == true)
            {
                keterangan = "Mendapatkan bagian 1/8 dari harta warisan karena mayit meninggalkan cucu perempuan";
            }
            else if (cicitpr == true)
            {
                keterangan = "Mendapatkan bagian 1/8 dari harta warisan karena mayit meninggalkan cicit perempuan";
            }
            else
            {
                keterangan = "Mendapatkan bagian 1/4 dari harta warisan karena mayit tidak meninggalkan anak/cucu/cicit (laki-laki atau perempuan).";
            }
            return keterangan;
        }
    }
}