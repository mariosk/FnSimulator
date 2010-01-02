using System;
using System.Reflection;
using System.Runtime.CompilerServices;

// Information about this assembly is defined by the following
// attributes.
//
// change them to the information which is associated with the assembly
// you compile.

[assembly: AssemblyTitle("Fn Simulation")]
[assembly: AssemblyDescription("This utility simulates the Fn key hold down process")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("TeleSoft")]
[assembly: AssemblyProduct("FnS")]
[assembly: AssemblyCopyright("Marios Karagiannopoulos (c) 2009")]
[assembly: AssemblyTrademark("FnS")]
[assembly: AssemblyCulture("")]

// The assembly version has following format :
//
// Major.Minor.Build.Revision
//
// You can specify all values by your own or you can build default build and revision
// numbers with the '*' character (the default):

[assembly: AssemblyVersion("1.1")]

// The following attributes specify the key for the sign of your assembly. See the
// .NET Framework documentation for more information about signing.
// This is not required, if you don't want signing let these attributes like they're.
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]

namespace FnSimulation
{
    # region "zClass to get the information for AboutForm"
    /* This class uses the System.Reflection.Assembly class to access assembly meta-data.
 * This class is not a normal feature of AssmblyInfo.cs */
    /// <summary>
    /// AssemblyInfo class.
    /// </summary>
    public class AssemblyInfo
    {
        //Used by functions to access information from Assembly Attributes
        /// <summary>O.                      
        /// myType.
        /// </summary>
        private Type myType;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyInfo"/> class.
        /// </summary>
        public AssemblyInfo()
        {
            //Shellform here denotes the actual form.
            myType = typeof(MainForm);
        }

        /// <summary>
        /// Gets the name of the assembly.
        /// </summary>
        /// <value>The name of the assembly.</value>
        public String AssemblyName
        {
            get
            {
                return myType.Assembly.GetName().Name.ToString();
            }
        }

        /// <summary>
        /// Gets the full name of the assembly.
        /// </summary>
        /// <value>The full name of the assembly.</value>
        public String AssemblyFullName
        {
            get
            {
                return myType.Assembly.GetName().FullName.ToString();
            }
        }

        /// <summary>
        /// Gets the code base.
        /// </summary>
        /// <value>The code base.</value>
        public String CodeBase
        {
            get
            {
                return myType.Assembly.CodeBase;
            }
        }

        /// <summary>
        /// Gets the copyright.
        /// </summary>
        /// <value>The copyright.</value>
        public String Copyright
        {
            get
            {
                Type att = typeof(AssemblyCopyrightAttribute);
                object[] r = myType.Assembly.GetCustomAttributes(att, false);
                AssemblyCopyrightAttribute copyattr = (AssemblyCopyrightAttribute)r[0];
                return copyattr.Copyright;
            }
        }

        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <value>The company.</value>
        public String Company
        {
            get
            {
                Type att = typeof(AssemblyCompanyAttribute);
                object[] r = myType.Assembly.GetCustomAttributes(att, false);
                AssemblyCompanyAttribute compattr = (AssemblyCompanyAttribute)r[0];
                return compattr.Company;
            }
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        public String Description
        {
            get
            {
                Type att = typeof(AssemblyDescriptionAttribute);
                object[] r = myType.Assembly.GetCustomAttributes(att, false);
                AssemblyDescriptionAttribute descattr = (AssemblyDescriptionAttribute)r[0];
                return descattr.Description;
            }
        }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <value>The product.</value>
        public String Product
        {
            get
            {
                Type att = typeof(AssemblyProductAttribute);
                object[] r = myType.Assembly.GetCustomAttributes(att, false);
                AssemblyProductAttribute prodattr = (AssemblyProductAttribute)r[0];
                return prodattr.Product;
            }
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>The title.</value>
        public String Title
        {
            get
            {
                Type att = typeof(AssemblyTitleAttribute);
                object[] r = myType.Assembly.GetCustomAttributes(att, false);
                AssemblyTitleAttribute titleattr = (AssemblyTitleAttribute)r[0];
                return titleattr.Title;
            }
        }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>The version.</value>
        public String Version
        {
            get
            {
                return myType.Assembly.GetName().Version.ToString();
            }
        }
    }
    # endregion
}