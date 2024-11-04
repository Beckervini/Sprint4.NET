using Xunit;
using Sprint1_2semestre.Services;

public class ConfigManagerTests
{
    [Fact]
    public void Should_Return_Singleton_Instance()
    {
        // Arrange & Act
        var instance1 = ConfigManager.GetInstance();
        var instance2 = ConfigManager.GetInstance();

        // Assert
        Assert.Same(instance1, instance2);
    }

    [Fact]
    public void Should_Update_ConfigValue()
    {
        // Arrange
        var configManager = ConfigManager.GetInstance();
        var newValue = "Novo valor";

        // Act
        configManager.UpdateConfigValue(newValue);

        // Assert
        Assert.Equal(newValue, configManager.ConfigValue);
    }
}
