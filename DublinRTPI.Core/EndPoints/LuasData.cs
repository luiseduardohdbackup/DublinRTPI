using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using DublinRTPI.Core.Entities;
using DublinRTPI.Core.Contracs;
using DublinRTPI.Core.DataAccess;

namespace DublinRTPI.Core.EndPoints
{
	internal static class LuasData
	{
		public static List<Station> STATIONS = new List<Station>() {
			new Station() { 
				Name = "St. Stephen's Green", 
				Id = "St. Stephen's Green", 
				Latitude = 53.339214, 
				Longitude = -6.261177 
			},
			new Station() {
				Name = "Harcourt",
				Id = "Harcourt",
				Latitude = 53.333346,
				Longitude = -6.262749
			},
			new Station() {
				Name = "Charlemont",
				Id = "Charlemont",
				Latitude = 53.330674,
				Longitude = -6.258648
			},
			new Station() {
				Name = "Ranelagh",
				Id = "Ranelagh",
				Latitude = 53.326431,
				Longitude = -6.256263
			},
			new Station() {
				Name = "Beechwood",
				Id = "Beechwood",
				Latitude = 53.320816,
				Longitude = -6.254705
			},
			new Station() {
				Name = "Cowper",
				Id = "Cowper",
				Latitude = 53.316469,
				Longitude = -6.253404
			},
			new Station() {
				Name = "Milltown",
				Id = "Milltown",
				Latitude = 53.30992,
				Longitude = -6.251685
			},
			new Station() {
				Name = "Windy Arbour",
				Id = "Windy Arbour",
				Latitude = 53.301556,
				Longitude = -6.250786
			},
			new Station() {
				Name = "Dundrum",
				Id = "Dundrum",
				Latitude = 53.292364,
				Longitude = -6.245065
			},
			new Station() {
				Name = "Balally",
				Id = "Balally",
				Latitude = 53.286105,
				Longitude = -6.236774
			},
			new Station() {
				Name = "Kilmacud",
				Id = "Kilmacud",
				Latitude = 53.282984,
				Longitude = -6.223886
			},
			new Station() {
				Name = "Stillorgan",
				Id = "Stillorgan",
				Latitude = 53.279331,
				Longitude = -6.209904
			},
			new Station() {
				Name = "Sandyford",
				Id = "Sandyford",
				Latitude = 53.277623,
				Longitude = -6.204666
			},
			new Station() {
				Name = "Central Park",
				Id = "Central Park",
				Latitude = 53.270146,
				Longitude = -6.203713
			},
			new Station() {
				Name = "Glencairn",
				Id = "Glencairn",
				Latitude = 53.266331,
				Longitude = -6.209907
			},
			new Station() {
				Name = "The Gallops",
				Id = "The Gallops",
				Latitude = 53.261144,
				Longitude = -6.206074
			},
			new Station() {
				Name = "Leopardstown Valley",
				Id = "Leopardstown Valley",
				Latitude = 53.258227,
				Longitude = -6.198379
			},
			new Station() {
				Name = "Ballyogan Wood",
				Id = "Ballyogan Wood",
				Latitude = 53.255017,
				Longitude = -6.184503
			},
			new Station() {
				Name = "Carrickmines",
				Id = "Carrickmines",
				Latitude = 53.254002,
				Longitude = -6.169931
			},
			new Station() {
				Name = "Laughanstown",
				Id = "Laughanstown",
				Latitude = 53.2506,
				Longitude = -6.154964
			},
			new Station() {
				Name = "Cherrywood",
				Id = "Cherrywood",
				Latitude = 53.245317,
				Longitude = -6.145898
			},
			new Station() {
				Name = "Brides Glen",
				Id = "Brides Glen",
				Latitude = 53.242083,
				Longitude = -6.142843
			},
			new Station() {
				Name = "Saggart",
				Id = "Saggart",
				Latitude = 53.28483,
				Longitude = -6.43904
			},
			new Station() {
				Name = "Fortunestown",
				Id = "Fortunestown",
				Latitude = 53.28441,
				Longitude = -6.42501
			},
			new Station() {
				Name = "Citywest Campus",
				Id = "Citywest Campus",
				Latitude = 53.28781,
				Longitude = -6.42022
			},
			new Station() {
				Name = "Cheeverstown",
				Id = "Cheeverstown",
				Latitude = 53.29103,
				Longitude = -6.40760
			},
			new Station() {
				Name = "Fettercairn",
				Id = "Fettercairn",
				Latitude = 53.29395,
				Longitude = -6.3957
			},
			new Station() {
				Name = "Tallaght",
				Id = "Tallaght",
				Latitude = 53.28771,
				Longitude = -6.37359
			},
			new Station() {
				Name = "Hospital",
				Id = "Hospital",
				Latitude = 53.289591,
				Longitude = -6.37930
			},
			new Station() {
				Name = "Cookstown",
				Id = "Cookstown",
				Latitude = 53.294253,
				Longitude = -6.38623
			},
			new Station() {
				Name = "Belgard",
				Id = "Belgard",
				Latitude = 53.29874,
				Longitude = -6.37450
			},
			new Station() {
				Name = "Kingswood",
				Id = "Kingswood",
				Latitude = 53.30247,
				Longitude = -6.36862
			},
			new Station() {
				Name = "Red Cow",
				Id = "Red Cow",
				Latitude = 53.31666,
				Longitude = -6.36939
			},
			new Station() {
				Name = "Kylemore",
				Id = "Kylemore",
				Latitude = 53.32649,
				Longitude = -6.34390
			},
			new Station() {
				Name = "Bluebell",
				Id = "Bluebell",
				Latitude = 53.32930,
				Longitude = -6.33396
			},
			new Station() {
				Name = "Blackhorse",
				Id = "Blackhorse",
				Latitude = 53.334192,
				Longitude = -6.32793
			},
			new Station() {
				Name = "Drimnagh",
				Id = "Drimnagh" ,
				Latitude = 53.335383,
				Longitude = -6.31833
			},
			new Station() {
				Name = "Goldenbridge",
				Id = "Goldenbridge",
				Latitude = 53.335857,
				Longitude = -6.31366
			},
			new Station() {
				Name = "Suir Road",
				Id = "Suir Road",
				Latitude = 53.33664,
				Longitude = -6.30733
			},
			new Station() {
				Name = "Rialto",
				Id = "Rialto" ,
				Latitude = 53.337869,
				Longitude = -6.29750
			},
			new Station() {
				Name = "Fatima",
				Id = "Fatima",
				Latitude = 53.338350,
				Longitude = -6.29277
			},
			new Station() {
				Name = "James's",
				Id = "James's",
				Latitude = 53.342033,
				Longitude = -6.29384
			},
			new Station() {
				Name = "Heuston",
				Id = "Heuston",
				Latitude = 53.346388,
				Longitude = -6.29223
			},
			new Station() {
				Name = "Museum",
				Id = "Museum" ,
				Latitude = 53.347842,
				Longitude = -6.2867
			},
			new Station() {
				Name = "Smithfield",
				Id = "Smithfield",
				Latitude = 53.347259,
				Longitude = -6.27860
			},
			new Station() {
				Name = "Four Courts",
				Id = "Four Courts",
				Latitude = 53.346824,
				Longitude = -6.27291
			},
			new Station() {
				Name = "Jervis",
				Id = "Jervis",
				Latitude = 53.347669,
				Longitude = -6.26609
			},
			new Station() {
				Name = "Abbey Street",
				Id = "Abbey Street",
				Latitude = 53.348588,
				Longitude = -6.258371
			},
			new Station() {
				Name = "Connolly",
				Id = "Connolly",
				Latitude = 53.351499,
				Longitude = -6.24993
			},
			new Station() {
				Name = "Busáras",
				Id = "Bus%E1ras",
				Latitude = 53.350289,
				Longitude = -6.25277
			},
			new Station() {
				Name = "George's Dock",
				Id = "George's Dock",
				Latitude = 53.34961,
				Longitude = -6.24807
			},
			new Station() {
				Name = "Mayor Square - NCI",
				Id = "Mayor Square - NCI",
				Latitude = 53.34933,
				Longitude = -6.24355
			},
			new Station() {
				Name = "Spencer Dock",
				Id = "Spencer Dock",
				Latitude = 53.34882,
				Longitude = -6.23718
			},
			new Station() {
				Name = "The Point",
				Id = "The Point",
				Latitude = 53.34834,
				Longitude = -6.22962
			}
		};
	}
}