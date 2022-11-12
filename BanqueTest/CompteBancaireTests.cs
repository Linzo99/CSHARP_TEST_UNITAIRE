using CompteBanqueNS;

namespace BanqueTests;


[TestClass]
public class CompteBancaireTests
{
    [TestMethod]
    public void VerifierDebitCompteCorrect()
    {
        double soldeInitial = 500000;
        double montantDebit = 400000;
        double soldeAttendu = 100000;

        CompteBancaire compte = new CompteBancaire("Pr. Alioune Sall", soldeInitial);

        compte.Debiter(montantDebit);

        double soldeObtneu = compte.Balance;
        Assert.AreEqual(soldeAttendu, soldeObtneu, 0.001, "Le solde attendu n'est celui obtenu");
    }

    [TestMethod]
    [ExpectedExceptionAttribute(typeof(ArgumentOutOfRangeException))]
    public void DebiterMontantSuperieurSoldeLeveArgumentOutOfRange() { 
        double soldeInitial = 500000;
        double montantDebit = 700000;

        CompteBancaire compte = new CompteBancaire("Pr. Alioune Sall", soldeInitial);

        compte.Debiter(montantDebit);
    }
    
    [TestMethod]
    [ExpectedExceptionAttribute(typeof(ArgumentOutOfRangeException))]
    public void DebiterMontantNegatifLeveArgumentOutOfRange() { 
        double soldeInitial = 500000;
        double montantDebit = -200000;

        CompteBancaire compte = new CompteBancaire("Pr. Alioune Sall", soldeInitial);

        compte.Debiter(montantDebit);
    }
}