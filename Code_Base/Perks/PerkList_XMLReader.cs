using System.Collections.Generic;
using System.Xml.Linq;

namespace Long_War_Assistant.Code_Base.Perks
{

    /// <summary>
    /// Reads the perk portion of the MainInformationFile
    /// TODO - probably combine into a single reader with various elements
    /// </summary>
    public class PerkList_XMLReader
    {
        public PerkList_XMLReader() { }

        public static List<Perk> ReadPerkList()
        {
            // Grab the master information file
            XElement _root = XElement.Parse(ProjectResources.MasterInformationFile);
            IEnumerable<XElement> _perkMasterList = _root.Descendants("PerkList");
            List<Perk> _perkList = new();

            // Go through each element in the perk list tag and make it a perk
            foreach (XElement perk in _perkMasterList.Descendants("Perk"))
            {
                _perkList.Add(ReadInformation(perk));
            }

            return _perkList;
        }

        private static Perk ReadInformation(XElement perk)
        {
            string _name = perk.Element("Name").Value.ToString();
            string _description = perk.Element("Description").Value.ToString();

            return new Perk(_name, _description);
        }
    }
}