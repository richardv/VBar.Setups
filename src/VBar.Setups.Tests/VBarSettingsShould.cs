namespace VBar.Setups.Tests;

using FluentAssertions;

[TestFixture]
public class VBarSettingsShould
{
    [Test]
    public void ArBank_Default_ReturnsFalse()
    {
        // Arrange
        var sut = NewVBarSettings("New 700");

        // Act
        var result = sut.ArBank();

        // Assert
        result.Should().BeFalse();
    }

    private VBarSettings NewVBarSettings(string setup)
    {
        using var file = new FileStream($"Setups/{setup}", FileMode.Open);

        return new VBarSettings("Test Setup", file);
    }

    [Test]
    public void CollectiveMax_Default_Returns100()
    {
        // Arrange
        var sut = NewVBarSettings("New 700");

        // Act
        var result = sut.CollectiveMax();

        // Assert
        result.Should().Be(100);
    }

    [Test]
    public void CollectiveMin_Default_ReturnsMinus100()
    {
        // Arrange
        var sut = NewVBarSettings("New 700");

        // Act
        var result = sut.CollectiveMin();

        // Assert
        result.Should().Be(-100);
    }

    [Test]
    public void GovernorType_Default_ReturnsExternalGov()
    {
        // Arrange
        var sut = NewVBarSettings("New 700");

        // Act
        var result = sut.GovernorType();

        // Assert
        result.Should().Be("External Governor");
    }

    [Test]
    public void GovernorType_VBarGov_ReturnsVBarGov()
    {
        // Arrange
        var sut = NewVBarSettings("New 700 VBar Gov");

        // Act
        var result = sut.GovernorType();

        // Assert
        result.Should().Be("VBar Electric Governor");
    }

    [Test]
    public void TailControl_Default_ReturnsServo()
    {
        // Arrange
        var sut = NewVBarSettings("New 700");

        // Act
        var result = sut.TailControl();

        // Assert
        result.Should().Be("Servo");
    }

    [Test]
    public void SensorDirection_Default_ReturnsDefault()
    {
        // Arrange
        var sut = NewVBarSettings("New 700");

        // Act
        var result = sut.SensorDirection();

        // Assert
        result.Should().Be("Face Up, Wire Front");
    }

    [Test]
    public void ExternalSensor_Default_ReturnsNoSensor()
    {
        // Arrange
        var sut = NewVBarSettings("New 700");

        // Act
        var result = sut.ExternalSensor();

        // Assert
        result.Should().Be("No external sensor");
    }

    [Test]
    public void Version_Default_ReturnsExternalGov()
    {
        // Arrange
        var sut = NewVBarSettings("New 700");

        // Act
        var result = sut.Version();

        // Assert
        result.Should().Be("6.4.86");
    }

    [Test]
    public void RxVoltage_Default_ReturnsZero()
    {
        // Arrange
        var sut = NewVBarSettings("New 700");

        // Act
        var result = sut.RxVoltageWarning();

        // Assert
        result.Should().Be(0);
    }

    [Test]
    public void CyclicCalibration_Default_Returns100()
    {
        // Arrange
        var sut = NewVBarSettings("New 700");

        // Act
        var result = sut.CyclicCalibration();

        // Assert
        result.Should().Be(100);
    }

    [Test]
    public void GearRatio_Default_Returns96()
    {
        // Arrange
        var sut = NewVBarSettings("New 700");

        // Act
        var result = sut.MainGearRatio();

        // Assert
        result.Should().Be(9.6);
    }

    [Test]
    public void SwashType_Default_ReturnsHR3Rev()
    {
        // Arrange
        var sut = NewVBarSettings("New 700");

        // Act
        var result = sut.SwashplateType();

        // Assert
        result.Should().Be("HR-3 (120° Rev)");
    }

    [Test]
    public void RotorDir_Default_ReturnsCW()
    {
        // Arrange
        var sut = NewVBarSettings("New 700");

        // Act
        var result = sut.MainRotorDirection();

        // Assert
        result.Should().Be("CW Main Rotor");
    }

    [Test]
    public void TailServo_Default_ReturnsNotSelected()
    {
        // Arrange
        var sut = NewVBarSettings("New 700");

        // Act
        var result = sut.TailServoType();

        // Assert
        result.Should().Be(" / 1500/1520");
    }

}