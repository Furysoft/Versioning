// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetVersionTests.cs" company="Simon Paramore">
// © 2017, Simon Paramore
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Furysoft.Versioning.Tests.Unit.GetVersion
{
    using System;
    using System.Diagnostics;
    using NUnit.Framework;
    using TestEntities;

    /// <summary>
    /// The Get Version Tests
    /// </summary>
    public sealed class GetVersionTests : TestBase
    {
        /// <summary>
        /// Gets the version when no version expect version0.
        /// </summary>
        [Test]
        public void GetVersion_WhenNoVersion_ExpectVersion0()
        {
            // Arrange
            var entity = new TestEntity();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var version = entity.GetVersion().ToString();
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(version, Is.EqualTo("TestEntity.0.0.0"));
            Console.WriteLine($"v{version}");
        }

        /// <summary>
        /// Gets the version when no version with type expect version0.
        /// </summary>
        [Test]
        public void GetVersion_WhenNoVersionWithType_ExpectVersion0()
        {
            // Arrange
            var entity = new TestEntity();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var version = typeof(TestEntity).GetVersion().ToString();
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(version, Is.EqualTo("TestEntity.0.0.0"));
            Console.WriteLine($"v{version}");
        }

        /// <summary>
        /// Gets the version when typed version0 0 1 expect typed version0 0 1.
        /// </summary>
        [Test]
        public void GetVersion_WhenTypedVersion0_0_1_ExpectTypedVersion0_0_1()
        {
            // Arrange
            var entity = new TypedTestEntityV001();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var version = entity.GetVersion().ToString();
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(version, Is.EqualTo("TypedTestEntityV001.0.0.1"));
            Console.WriteLine($"v{version}");
        }

        /// <summary>
        /// Gets the version when typed version0 0 1 rc 1 expect typed version0 0 1 rc 1.
        /// </summary>
        [Test]
        public void GetVersion_WhenTypedVersion0_0_1_rc_1_ExpectTypedVersion0_0_1_rc_1()
        {
            // Arrange
            var entity = new TypedTestEntityV001rc1();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var version = entity.GetVersion().ToString();
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(version, Is.EqualTo("TypedTestEntityV001rc1.0.0.1-rc.1"));
            Console.WriteLine($"v{version}");
        }

        /// <summary>
        /// Gets the version when version0 0 0 expect version0.
        /// </summary>
        [Test]
        public void GetVersion_WhenVersion0_0_0_ExpectVersion0()
        {
            // Arrange
            var entity = new TestEntityV0();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var version = entity.GetVersion().ToString();
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(version, Is.EqualTo("0.0.0"));
            Console.WriteLine($"v{version}");
        }

        /// <summary>
        /// Gets the version when version0 0 1 expect version0 0 1.
        /// </summary>
        [Test]
        public void GetVersion_WhenVersion0_0_1_ExpectVersion0_0_1()
        {
            // Arrange
            var entity = new TestEntityV001();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var version = entity.GetVersion().ToString();
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(version, Is.EqualTo("0.0.1"));
            Console.WriteLine($"v{version}");
        }

        /// <summary>
        /// Gets the version when version0 0 1 rc 1 expect version0 0 1 rc 1.
        /// </summary>
        [Test]
        public void GetVersion_WhenVersion0_0_1_rc_1_ExpectVersion0_0_1_rc_1()
        {
            // Arrange
            var entity = new TestEntityV001rc1();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var version = entity.GetVersion().ToString();
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(version, Is.EqualTo("0.0.1-rc.1"));
            Console.WriteLine($"v{version}");
        }

        /// <summary>
        /// Gets the version when version0 0 1 rc expect version0 0 1 rc.
        /// </summary>
        [Test]
        public void GetVersion_WhenVersion0_0_1_rc_ExpectVersion0_0_1_rc()
        {
            // Arrange
            var entity = new TestEntityV001rc();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var version = entity.GetVersion().ToString();
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(version, Is.EqualTo("0.0.1-rc"));
            Console.WriteLine($"v{version}");
        }

        /// <summary>
        /// Gets the version when version0 0 1 from type expect version0 0 1.
        /// </summary>
        [Test]
        public void GetVersion_WhenVersion0_0_1FromType_ExpectVersion0_0_1()
        {
            // Arrange
            var entity = new TestEntityV001();

            // Act
            var stopwatch = Stopwatch.StartNew();
            var version = typeof(TestEntityV001).GetVersion().ToString();
            stopwatch.Stop();

            // Assert
            this.WriteTimeElapsed(stopwatch);

            Assert.That(version, Is.EqualTo("0.0.1"));
            Console.WriteLine($"v{version}");
        }
    }
}