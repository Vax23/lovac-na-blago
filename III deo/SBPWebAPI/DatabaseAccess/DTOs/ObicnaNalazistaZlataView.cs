using DatabaseAccess.Entiteti;
using System;

namespace DatabaseAccess.DTOs
{
    public class ObicnaNalazistaZlataView
    {
        public  int ONZId { get; set; }
        public  string ONZIme { get; set; }
        public string ONZZemljaNalazenja { get; set; }
        public string ONZImeNalazaca { get; set; }
        public DateTime ONZDatumOtkrivanja { get; set; }

        public ObicnaNalazistaZlataView()
        {

        }

        public ObicnaNalazistaZlataView(ObicnaNalazistaZlata onz)
        {
            ONZId = onz.Id;
            ONZIme = onz.Ime;
            ONZZemljaNalazenja = onz.ZemljaNalazenja;
            ONZImeNalazaca = onz.ImeNalazaca;
            ONZDatumOtkrivanja = onz.DatumOtkrivanja;
        }
    }
}
