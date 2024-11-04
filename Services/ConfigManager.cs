namespace Sprint1_2semestre.Services
{
    public class ConfigManager
    {
        // Inst�ncia �nica (Singleton) da classe ConfigManager
        private static ConfigManager? _instance;
        private static readonly object _lock = new object();

        // Propriedade de exemplo que armazena um valor de configura��o
        public string ConfigValue { get; private set; }

        // Construtor p�blico sem par�metros (necess�rio para inje��o de depend�ncias)
        public ConfigManager()
        {
            // Definindo um valor inicial de configura��o
            ConfigValue = "Valor de configura��o inicial";
        }

        // M�todo est�tico para retornar a inst�ncia �nica do Singleton
        public static ConfigManager GetInstance()
        {
            // Garantindo que apenas uma inst�ncia seja criada
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

        // M�todo para atualizar o valor da configura��o
        public void UpdateConfigValue(string newValue)
        {
            ConfigValue = newValue;
        }
    }
}
