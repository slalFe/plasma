using System.Collections.Generic;
using System.Linq;
using System.Xml;
using NUnit.Framework;
using Plasma.WebDriver.Finders;

namespace Plasma.Test.Unit.WebDriver.Finders
{
    [TestFixture]
    public class ElementByClassNameFinderTests
    {
        [TestCase("foo", "foo", Description = "Basic fully matching class name")]
        [TestCase("foo", "foo", Description = "Matching one of several class names - at beginning")]
        [TestCase("foo", "foo bar baz wibble", Description = "Matching one of several class names - at beginning")]
        [TestCase("foo", "bar baz wibble foo", Description = "Matching one of several class names - at end")]
        [TestCase("foo", "bar baz foo wibble", Description = "Matching one of several class names - in middle")]
        public void ShouldFindAnElementThatHasClassNameInClassAttribute(string classToFind, string classAttributeValue)
        {
            string xmlSource = string.Format(@"<html>
                                                    <body>
                                                        <div>
                                                            <div>
                                                                <div id='elementToFind' class='{0}'></div>
                                                            </div>
                                                         </div>
                                                    </body>
                                                </html>", classAttributeValue);

            var document = new XmlDocument();
            document.LoadXml(xmlSource);

            IEnumerable<XmlElement> xmlElements = new ElementByClassNameFinder(classToFind).FindWithin(document.DocumentElement);

            Assert.That(xmlElements.Count(), Is.EqualTo(1), "Failed to locate a single element with class name " + classToFind + " within XML Source "+ xmlSource);
            Assert.That(xmlElements.Single().GetAttribute("id"), Is.EqualTo("elementToFind"));
        }
    }
}