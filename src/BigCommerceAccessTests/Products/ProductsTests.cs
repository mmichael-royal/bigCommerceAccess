﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BigCommerceAccess;
using BigCommerceAccess.Models.Configuration;
using BigCommerceAccess.Models.Product;
using FluentAssertions;
using LINQtoCSV;
using Netco.Logging;
using NUnit.Framework;

namespace BigCommerceAccessTests.Products
{
	[ TestFixture ]
	public class ProductsTests
	{
		private readonly IBigCommerceFactory BigCommerceFactory = new BigCommerceFactory();
		private BigCommerceConfig ConfigV2;
		private BigCommerceConfig ConfigV3;

		[ SetUp ]
		public void Init()
		{
			NetcoLogger.LoggerFactory = new ConsoleLoggerFactory();
			const string credentialsFilePath = @"..\..\Files\BigCommerceCredentials.csv";

			var cc = new CsvContext();
			var testConfig = cc.Read< TestConfig >( credentialsFilePath, new CsvFileDescription { FirstLineHasColumnNames = true, IgnoreUnknownColumns = true } ).FirstOrDefault();

			if( testConfig != null )
			{
				this.ConfigV2 = new BigCommerceConfig( testConfig.ShopName, testConfig.UserName, testConfig.Token );
				this.ConfigV3 = new BigCommerceConfig( testConfig.ShortShopName, testConfig.ClientId, testConfig.ClientSecret, testConfig.ApiKey );
			}
		}

		[ Test ]
		public void GetProductsV2()
		{
			var service = this.BigCommerceFactory.CreateProductsService( this.ConfigV2 );
			var products = service.GetProducts( true );

			products.Count().Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public async Task GetProductsV2Async()
		{
			var service = this.BigCommerceFactory.CreateProductsService( this.ConfigV2 );
			var products = await service.GetProductsAsync( CancellationToken.None, true );

			products.Count().Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public void GetProductsV3()
		{
			var service = this.BigCommerceFactory.CreateProductsService( this.ConfigV3 );
			var products = service.GetProducts();

			products.Count().Should().BeGreaterThan( 0 );
		}

		[ Test ]
		public async Task GetProductsV3Async()
		{
			var service = this.BigCommerceFactory.CreateProductsService( this.ConfigV3 );
			var products = await service.GetProductsAsync( CancellationToken.None );

			products.Count().Should().BeGreaterThan( 0 );
		}

		//[ Test ]
		//public void GetProductsInfoV3()
		//{
		//	var service = this.BigCommerceFactory.CreateProductsService( this.ConfigV3 );
		//	var products = service.GetProductsInfo();

		//	products.Count().Should().BeGreaterThan( 0 );
		//}

		//[ Test ]
		//public async Task GetProductsInfoV3Async()
		//{
		//	var service = this.BigCommerceFactory.CreateProductsService( this.ConfigV3 );
		//	var products = await service.GetProductsInfoAsync( CancellationToken.None );

		//	products.Count().Should().BeGreaterThan( 0 );
		//}

		[ Test ]
		public void ProductsQuantityUpdatedV2()
		{
			var service = this.BigCommerceFactory.CreateProductsService( this.ConfigV2 );

			var productToUpdate = new BigCommerceProduct { Id = 74, Quantity = "1" };
			service.UpdateProducts( new List< BigCommerceProduct > { productToUpdate } );
		}

		[ Test ]
		public async Task ProductsQuantityUpdatedV2Async()
		{
			var service = this.BigCommerceFactory.CreateProductsService( this.ConfigV2 );

			var productToUpdate = new BigCommerceProduct { Id = 74, Quantity = "6" };
			await service.UpdateProductsAsync( new List< BigCommerceProduct > { productToUpdate }, CancellationToken.None );
		}

		[ Test ]
		public void ProductsQuantityUpdatedV3()
		{
			var service = this.BigCommerceFactory.CreateProductsService( this.ConfigV3 );

			var productToUpdate = new BigCommerceProduct { Id = 74, Quantity = "1" };
			service.UpdateProducts( new List< BigCommerceProduct > { productToUpdate } );
		}

		[ Test ]
		public async Task ProductsQuantityUpdatedV3Async()
		{
			var service = this.BigCommerceFactory.CreateProductsService( this.ConfigV3 );

			var productToUpdate = new BigCommerceProduct { Id = 74, Quantity = "6" };
			await service.UpdateProductsAsync( new List< BigCommerceProduct > { productToUpdate }, CancellationToken.None );
		}

		[ Test ]
		public void ProductOptionsQuantityUpdatedV2()
		{
			var service = this.BigCommerceFactory.CreateProductsService( this.ConfigV2 );

			var productToUpdate = new BigCommerceProductOption { ProductId = 45, Id = 53, Quantity = "6" };
			service.UpdateProductOptions( new List< BigCommerceProductOption > { productToUpdate } );
		}

		[ Test ]
		public async Task ProductOptionsQuantityUpdatedV2Async()
		{
			var service = this.BigCommerceFactory.CreateProductsService( this.ConfigV2 );

			var productToUpdate = new BigCommerceProductOption { ProductId = 45, Id = 53, Quantity = "6" };
			await service.UpdateProductOptionsAsync( new List< BigCommerceProductOption > { productToUpdate }, CancellationToken.None );
		}

		[ Test ]
		public void ProductOptionsQuantityUpdatedV3()
		{
			var service = this.BigCommerceFactory.CreateProductsService( this.ConfigV3 );

			var productToUpdate = new BigCommerceProductOption { ProductId = 45, Id = 53, Quantity = "6" };
			service.UpdateProductOptions( new List< BigCommerceProductOption > { productToUpdate } );
		}

		[ Test ]
		public async Task ProductOptionsQuantityUpdatedV3Async()
		{
			var service = this.BigCommerceFactory.CreateProductsService( this.ConfigV3 );

			var productToUpdate = new BigCommerceProductOption { ProductId = 45, Id = 53, Quantity = "6" };
			await service.UpdateProductOptionsAsync( new List< BigCommerceProductOption > { productToUpdate }, CancellationToken.None );
		}
	}
}