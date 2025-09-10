// See https://aka.ms/new-console-template for more information
using facturaApp.domain;
using facturaApp.services;
//factura
//---------------------------------
Billservices ob = new Billservices();
Console.WriteLine("obtener factura -getall");

List<Bill> lb = ob.getBills();

try
{
    if(lb.Count > 0)
    {
        foreach(Bill bi in lb)
        {
            Console.WriteLine(bi);
            Console.WriteLine("------------------------------------------------------");
        }
       
    }

}

catch (Exception ex)
{
    Console.WriteLine("no se ha encontrado facturas");
}

detailsService od=new detailsService();
Console.WriteLine("obtener su detalle -getall");

List<billDetails> ldb = od.getDetail();

try
{
    if (ldb.Count > 0)
    {
        foreach (billDetails d in ldb)
        {
            Console.WriteLine(d);
            Console.WriteLine("------------------------------------------------------");
        }

    }

}

catch (Exception ex)
{
    Console.WriteLine("no se ha encontrado los detalles de facturas");



}

Console.WriteLine("obtener factura por nro -getbyid");
Bill? b3 = ob.getbillbyID(2003);


if (b3 != null)
{
    Console.WriteLine(b3);
    Console.WriteLine("------------------------------------------------------");
}
else
{
    Console.WriteLine("no existe esa factura");
}

Console.WriteLine("------------------------------------------------------");


Console.WriteLine("crear una factura  -save");

Bill b = new Bill();
b.id = 2005;
b.date = DateTime.Now;
b.Type = 2;
b.client = "juan pacheco";

bool rc = ob.save(b);
if (rc)
{
    Console.WriteLine($"Se ha creado la factura!");
    Console.WriteLine("---------------------------------------------------");
}
else
{
    Console.WriteLine("No se ha podido crear la factura ");
}

Console.WriteLine("---------------------------------------------------");

Console.WriteLine("crear una factura y su detalle -save");

Bill bill = new Bill();
bill.id = 2004;  
bill.date = DateTime.Now;
bill.Type = 1; 
bill.client = "lisa Pacheco";
bill.details = new List<billDetails>();


billDetails details = new billDetails();
details.id = 1;    
details.count = 3;
details.nro = bill.id;
details.price = 13.500;     

bill.details.Add(details);

bool resultCreate = ob.Transaction(bill);

if (resultCreate)
{
    Console.WriteLine($"Se ha creado la factura!");
    Console.WriteLine("---------------------------------------------------");
}
else
{
    Console.WriteLine("No se ha podido crear la factura con su detalle");
}

Console.WriteLine("---------------------------------------------------");





//Console.WriteLine("articulos (cosa opcional)");

//Console.WriteLine("------------------------------------------------------");
////(prueba) articulo
////---------------------------------

//productServices o = new productServices();

//Console.WriteLine("obtener  los articulos - getall");

//List<Product> lp = o.GetProducts();

//if (lp.Count > 0)
//{
//    foreach(Product p in lp)
//    {
//        Console.WriteLine(p);
//        Console.WriteLine("------------------------------------------------------");
//    }

  
//}
//else 
//{
//    Console.WriteLine("no hay articulos");
      
//}

//Console.WriteLine("obtener articulos por id - getbyid");
//Product? p5 = o.GetProduct(5);

//if(p5 != null)
//{
//    Console.WriteLine(p5);
//    Console.WriteLine("------------------------------------------------------");
//}
//else
//{
//    Console.WriteLine("no existe ese articulo");
//}








