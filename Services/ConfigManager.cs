namespace Sprint1_2semestre.Services
{
    public class ConfigManager
    {
        // Instância única (Singleton) da classe ConfigManager
        private static ConfigManager? _instance;
        private static readonly object _lock = new object();

        // Propriedade de exemplo que armazena um valor de configuração
        public string ConfigValue { get; private set; }

        // Construtor público sem parâmetros (necessário para injeção de dependências)
        public ConfigManager()
        {
            // Definindo um valor inicial de configuração
            ConfigValue = "Valor de configuração inicial";
        }

        // Método estático para retornar a instância única do Singleton
        public static ConfigManager GetInstance()
        {
            // Garantindo que apenas uma instância seja criada
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ConfigManager();
                    }
                }
            }

            return _instance;
        }

        // Método para atualizar o valor da configuração
        public void UpdateConfigValue(string newValue)
        {
            ConfigValue = newValue;
        }
    }
}
