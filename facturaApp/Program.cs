// See https://aka.ms/new-console-template for more information
using facturaApp.domain;
using facturaApp.services;
using System.Net.NetworkInformation;
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
b.date =DateTime.Today;
b.Type = 1;
b.client = "spinetta";

bool rc = ob.save(b);
if (rc)
{
    Console.WriteLine("No se ha podido crear la factura ");
   
}
else
{
    Console.WriteLine($"Se ha creado la factura!");
    Console.WriteLine("---------------------------------------------------");
}

Console.WriteLine("actualizar factura -update");

Bill b2 = new Bill();
b2.id = 2004;
b2.date=DateTime.Today;
b2.Type = 2;
b2.client = "manuel lopez";

bool cr=ob.save(b2);
if (cr)
{
    Console.WriteLine("No se ha podido actualizar la factura porque no existe");

}
else
{
    Console.WriteLine($"Se ha actualizado la factura!");
    Console.WriteLine("---------------------------------------------------");
}


Console.WriteLine("---------------------------------------------------");

Console.WriteLine("crear una factura y su detalle -save");

Bill complexbill = new Bill()
{
    date = DateTime.Now,
    Type = 1,
    client = "elvis presley",
    details = new List<billDetails>()
    {
        new billDetails()
        {
          id = 1,
          count = 1,
          price = 4500
        }
    }
};

bool resultCreate = ob.Transaction(complexbill);

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


Console.WriteLine("eliminar  factura -delete");

bool result= ob.delete(2016);

if (result)
{

    Console.WriteLine($"Se he eliminado la factura!");
    Console.WriteLine("---------------------------------------------------");


}
else
{
    Console.WriteLine("No se ha podido eliminar la factura");
}


