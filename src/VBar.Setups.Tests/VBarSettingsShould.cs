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
}