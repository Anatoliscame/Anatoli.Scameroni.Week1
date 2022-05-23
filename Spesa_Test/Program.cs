// See https://aka.ms/new-console-template for more information
using Spesa_Test;
using Spesa_Test.Categoria;
using Spesa_Test.Factory;
using Spesa_Test.Handler;
using Spesa_Test.InterfaceFactory;
using Spesa_Test.InterfaceHandlre;
using Spesa_Test.Repository;

Console.WriteLine("Hello, World!");

var factory_C = new FactoryProdottoICattegoria();
ICategoria ris_cattegoria = factory_C.importoRimborsatoICattegoria("Vitto");

Console.WriteLine("Factory di Cattegoria \n" + ris_cattegoria);

ICategoria cat = ris_cattegoria;

/*
Servizio p1 = new Servizio(new DateTime(2000, 2, 3), cat, "Turistica in Italia", cat.Importo_Rimborsato(2100));
p1.Data_s = new DateTime(2000, 2, 3);
p1.Categoria = cat;
p1.Descrizione = "Turistica in Italia";
p1.Importo = 2100;
*/

RepositoryProdottoFile repoProd = new RepositoryProdottoFile();


//var esito = repoProd.Aggiungi(p1);

// RepositoryAlimentariMOCK repoAlim = new RepositoryAlimentariMOCK();
List<RepositoryProdottoFile> array_prodotti = new List<RepositoryProdottoFile>();

var listaProdotti = repoProd.GetAll();



for (int i = 0; i <listaProdotti.Count; i++)
{
    ICategoria cattegoria_scelta = factory_C.importoRimborsatoICattegoria(listaProdotti[i].Categoria.nomeC());

    double ris_prezzo = cattegoria_scelta.Importo_RimborsatoProdotto(listaProdotti[i]);

   Console.WriteLine(listaProdotti[i].Disegna()+" "+ ris_prezzo);
    }



Dipendente employee_CEO = new Dipendente()
{

    FirstName = "Anatoli",
    LastName = "Scame",
    DateOfBirth = new DateTime(1995, 02, 17),
    Euro = 100
};

IHandler managerHandler = new Manager();

IHandler managerHandler_Optional = new Operational_Manager();


IHandler managerHandler_CEO = new CEO();

IHandler spesa_vuota = new Nessuna_SpesaApprovata();

string euroManager = managerHandler.HandleRequest(employee_CEO);

string euroManager_Optional = managerHandler_Optional.HandleRequest(employee_CEO);

string euroManager_CEO = managerHandler_CEO.HandleRequest(employee_CEO);

//string euroManager_CEO1 = managerHandler_CEO.HandleRequest(employee_CEO1);

string euro_nonSpeso = spesa_vuota.HandleRequest(employee_CEO);

managerHandler.SetNext(managerHandler_Optional).SetNext(managerHandler_CEO).SetNext(spesa_vuota);
//managerHandler_CEO.SetNext(spesa_vuota).SetNext(managerHandler_CEO);
Console.WriteLine("euroManager \n" + euroManager);
Console.WriteLine("\n");
Console.WriteLine("euroManager_Optional \n" + euroManager_Optional);
Console.WriteLine("\n");
Console.WriteLine("euroManager_CEO \n" + euroManager_CEO);
Console.WriteLine("\n");
Console.WriteLine("euro_nonSpeso \n" + euro_nonSpeso);

/*
FactoryProdottoCattegoria factory = new FactoryProdottoCattegoria();

string factory_scelta = factory.importoRimborsato("Vitto");

Console.WriteLine("Factory \n" + factory_scelta);
*/




