using BibliotecaExamenTestUnitari;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject
{
    

    [TestClass]
    public class UnitTest1
    {
        String msg = "";
        String prova = "";
        String[] vdades;

        ClProveidorProva proveidor = null;

        ClBibilioRecu bbl = new ClBibilioRecu();


        [TestMethod]
        public void provaQuantesVocals()
        {
            List<ClVocals> llVocals = new List<ClVocals>();

            llVocals.Add(new ClVocals('a', 2));
            llVocals.Add(new ClVocals('e', 1));

            string v = "aaqtyrte";
            List<ClVocals> resultat;
            resultat = bbl.QuantesVocals(v);
            ///JAUME SI DEBUGUES AMB AQUEST RESULTATS SI QUE DONDEN EL MATEIX SI SON IGUALS , PERO SALTA ERROR
            CollectionAssert.AreEqual(llVocals, resultat);
        }
        [TestMethod]
        public void provaParaulesMesRepetides()
        {
            List<String> llistaResultat = new List<String>();

            llistaResultat.Add("4#quart");
            llistaResultat.Add("3#tercer");
            llistaResultat.Add("2#sise");
            llistaResultat.Add("2#segon");
            llistaResultat.Add("1#primer");
            llistaResultat.Add("1#cinque");

            CollectionAssert.AreEqual(llistaResultat, bbl.ParaulesMesRepetides("primer segon tercer quart cinque sise", "nove vuite sete sise sise cinque quart quart quart quart tercer tercer tercer segon segon primer"));
        }
        [TestMethod]
        public void provaCriptoEncode()
        {
            proveidor = new ClProveidorProva("CriptoEncode.txt");

            if (proveidor.fitxer != null)
            {
                prova = proveidor.NextProva();

                while (prova != "")
                {
                    vdades = prova.Split('#');
                    if (vdades.Length != 3)
                    {
                        Console.WriteLine("***ERROR*** ---> " + prova);
                    }
                    else
                    {
                        msg = "TESTING ---> " + vdades[0].ToString() + " - " + vdades[1].ToString();
                        Console.WriteLine(msg);
                        Assert.AreEqual(vdades[2], bbl.CriptoEncode(vdades[0], Int32.Parse(vdades[1])), msg);
                    }
                    prova = proveidor.NextProva();
                }
                proveidor.TancarProveidor();
            }
        }
        [TestMethod]
        public void provaCriptoDecode()
        {
            proveidor = new ClProveidorProva("CriptoDecode.txt");

            if (proveidor.fitxer != null)
            {
                prova = proveidor.NextProva();

                while (prova != "")
                {
                    vdades = prova.Split('#');
                    if (vdades.Length != 3)
                    {
                        Console.WriteLine("***ERROR*** ---> " + prova + vdades.Length);
                    }
                    else
                    {
                        msg = "TESTING ---> " + vdades[0].ToString() + " - " + vdades[1].ToString();
                        Assert.AreEqual(vdades[2], bbl.CriptoDecode(vdades[0], Int32.Parse(vdades[1])), msg);

                    }
                    prova = proveidor.NextProva();
                }
                proveidor.TancarProveidor();
            }
        }
    }
}
