/*
 * Created by Ranorex
 * User: Jacob Brennecke
 * Date: 5/27/2025
 * Time: 10:58 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace RivianR1Configurator
{
    /// <summary>
    /// Creates a Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class VehiclePriceCalculator
    {
        // You can use the "Insert New User Code Method" functionality from the context menu,
        // to add a new method with the attribute [UserCodeMethod].
        
        /// <summary>
        /// This method will initialize the price of the vehicle based on the trim level
        /// </summary>
        [UserCodeMethod]
        public static void InitializeBasePrice(string basePrice)
        {
        	TestSuite.Current.Parameters["TotalVehicleCost"] = basePrice;
        	Report.Info("Vehicle Base Price: " + basePrice);
        }
        
        
        /// <summary>
        /// Add the cost of any item to the current vehicle cost
        /// </summary>
        [UserCodeMethod]
        public static void AddOptionCost(string optionCost)
        {
        	int totalVehicleCost = Int32.Parse(TestSuite.Current.Parameters["TotalVehicleCost"]);
        	int intOptionCost = Int32.Parse(optionCost);
        	int newTotalVehicleCost = totalVehicleCost + intOptionCost;
        	string newTotalVehicleCostString = ConvertToCurrencyFormattedString(newTotalVehicleCost.ToString());
        	TestSuite.Current.Parameters["TotalVehicleCost"] = newTotalVehicleCost.ToString();
        	
        	Report.Info("Current Vehicle Total Price: " + newTotalVehicleCostString);
        }
        
        
        /// <summary>
        /// Convert the calculated value of the vehicle price to a string
        /// </summary>
        [UserCodeMethod]
        public static string ConvertToCurrencyFormattedString(string vehicleCost)
        {        	
        	decimal cost = Decimal.Parse(vehicleCost);
        	return cost.ToString("C0");
        }
    }
}
