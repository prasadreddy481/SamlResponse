namespace ConsoleApp2
{
    using ComponentSpace.SAML2;
    using ComponentSpace.SAML2.Assertions;
    using ComponentSpace.SAML2.Protocols;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            var issuer = new Issuer("Test.com");

            var samlResponse = new SAMLResponse { Destination = "test.com", Issuer = issuer, Status = new Status(SAMLIdentifiers.PrimaryStatusCodes.Success, null) };

            var samlAssertion = new SAMLAssertion { Issuer = issuer, Subject = null, Conditions = new Conditions { NotBefore = DateTime.Now, NotOnOrAfter = DateTime.Now.AddMinutes(5), } };

            AttributeStatement attStatement = new AttributeStatement();

            attStatement.Attributes.Add(new SAMLAttribute("Test", SAMLIdentifiers.AttributeNameFormats.Basic, "xxx", "xxxx"));

            samlAssertion.Statements.Add(attStatement);

            samlResponse.Assertions.Add(samlAssertion); // Sign the SAML response. var samlResponseXml = samlResponse.ToXml();

            var x = samlResponse.ToXml();

            Console.WriteLine(x.OuterXml);

            Console.ReadLine();
        }
    }
}
