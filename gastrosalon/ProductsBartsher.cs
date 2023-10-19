using System.Xml.Serialization;

namespace gastrosalon
{
    [Serializable]
    [XmlRoot("product")]
    public class ProductsBartsher
    {
        [XmlElement]
        public string Code { get; set; }

        [XmlElement(ElementName = "name")]
        public List<Value> Value { get; set; }

        [XmlElement]
        public string ProductType { get; set; }

        [XmlElement]
        public string Gtin { get; set; }

        [XmlElement]
        public string NetWidth { get; set; }

        [XmlElement]
        public string NetDepth { get; set; }

        [XmlElement]
        public string NetHeight { get; set; }

        [XmlElement]
        public string NetWeight { get; set; }

        [XmlElement]
        public string GrossWeight { get; set; }

        [XmlElement]
        public string WeightUnit { get; set; }

        [XmlElement]
        public string Volume { get; set; }

        [XmlElement]
        public string VolumeUnit { get; set; }

        [XmlElement]
        public string ListPrice {  get; set; }

        [XmlElement]
        public string Currency {  get; set; }

        [XmlElement]
        public string DiscountGroup { get; set; }

        [XmlElement]
        public string Guarantee { get; set; }

        [XmlElement]
        public string Servicing { get; set; }

        [XmlElement]
        public string CustomsTarifNumber { get; set; }

        [XmlElement]
        public string Packaging { get; set; }

        [XmlElement(ElementName = "datasheet")]
        public List<Value> DataSheetValue { get; set; }

        [XmlElement(ElementName = "explodedview")]
        public List<Value> ExplodedViewValue { get; set; }

        [XmlElement(ElementName = "wiringdiagram")]
        public List<Value> WiringDiagramValue { get; set; }

        [XmlElement(ElementName = "operatinginstructions")]
        public List<Value> OperatingInstructionsValue { get; set; }

        [XmlElement]
        public string AccessoryProducts {  get; set; }

        [XmlElement]
        public string SimilarProducts {  get; set; }

        [XmlElement(ElementName = "category1")]
        public List<Value> Category1Value { get; set; }

        [XmlElement(ElementName = "category2")]
        public List<Value> Category2Value { get; set; }

        [XmlElement(ElementName = "Attribut1")]
        public List<Value> Attribut1Value { get; set; }

        [XmlElement(ElementName = "Attribut2")]
        public List<Value> Attribut2Value { get; set; }

        [XmlElement(ElementName = "Attribut3")]
        public List<Value> Attribut3Value { get; set; }

        [XmlElement(ElementName = "Attribut4")]
        public List<Value> Attribut4Value { get; set; }

        [XmlElement(ElementName = "Attribut5")]
        public List<Value> Attribut5Value { get; set; }

        [XmlElement(ElementName = "Attribut6")]
        public List<Value> Attribut6Value { get; set; }

        [XmlElement(ElementName = "Attribut7")]
        public List<Value> Attribut7Value { get; set; }

        [XmlElement(ElementName = "Attribut8")]
        public List<Value> Attribut8Value { get; set; }

        [XmlElement(ElementName = "Attribut9")]
        public List<Value> Attribut9Value { get; set; }

        [XmlElement(ElementName = "Attribut10")]
        public List<Value> Attribut10Value { get; set; }

        [XmlElement]
        public string Image1 {  get; set; } 
    }

    [XmlRoot(ElementName = "value")]
    public class Value
    {

        [XmlElement(ElementName = "attr")]
        public List<Attr> Attr { get; set; }
    }

    [XmlRoot(ElementName = "attr")]
    public class Attr
    {
        [XmlAttribute(AttributeName = "lang")]
        public string Language { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}   