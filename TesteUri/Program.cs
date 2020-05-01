using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteUri
{
    class Program
    {
        static Uri uri = new Uri("http://macoratti:password@authority.com:5555/path/pagina.aspx?valor1=10&valor2=20#fragment");

        static void Main(string[] args)
        {
            Uri uriAbsoluta = new Uri("http://www.macoratti.net");
            Console.WriteLine(uriAbsoluta);

            Uri uriRelativa = new Uri("c_uri1.htm", UriKind.Relative);
            Console.WriteLine(uriRelativa);

            Uri combinacao = new Uri(uriAbsoluta, uriRelativa);
            Console.WriteLine(combinacao);

            ExtraindoInfo();
            PropriedadesBooleanas();
            MakeRelativeUri();
            GetLeftPart();
            CheckHostName();
            CheckSchemeName();
            DigitosHexadecimais();

            Console.ReadLine();
        }        

        static void ExtraindoInfo()
        {
            Console.WriteLine($"\n\n=== Extraindo partes da URI: {uri} ");

            // Scheme: fornece o esquema da URI. Se você estiver atuando sobre uma URI pode usar o esquema para saber como carregá-lo.
            Console.WriteLine($"Scheme: {uri.Scheme}");

            // Authority: retorna a autoridade da URI como uma string e inclui o número da porta mas não inclui informação do usuário.
            Console.WriteLine($"Authority: {uri.Authority}");

            // UserInfo: retorna os detalhes do usuário. Não existe uma propriedade para obter o nome do usuário ou a senha individualmente. Mas podemos usar o método Split para separar essas informações.
            Console.WriteLine($"UserInfo: {uri.UserInfo}");

            // Port: retorna a porta usada como um inteiro.
            Console.WriteLine($"Port: {uri.Port}");

            // AbsolutePath: retorna o caminho da URI como uma string simples, iniciando com a barra inicial do caminho até o começo da consulta.
            Console.WriteLine($"AbsolutePath: {uri.AbsolutePath}");

            // Query: retorna a consulta incluindo o sinal de interrogação inicial.(?)
            Console.WriteLine($"Query: {uri.Query}");

            // Fragment: retorna o fragmento onde o separador de caractere agora é um hash(#) que é incluído no resultado.
            Console.WriteLine($"Fragment: {uri.Fragment}");

            // Host: retorna a parte do host da URI, geralmente o nome de um servidor, um nome DNS ou um endereço IP, e faz parte da autoridade mas não inclui o número da porta ou informação do usuário.
            Console.WriteLine($"Host: {uri.Host}");

            /* A propriedade HostNameType retorna o tipo do host, um valor da enumeração UriHostNameType, neste caso é Dns. Possíveis valores:
             * - Unknown - O tipo de nome do host não está presente na Uri;
             * - Basic - O tipo de nome do host está presente, mas não pode ser determinado;
             * - Dns - O nome do host é um host DNS, como "macoratti.net";
             * - IPv4 - O host é um endereço IP, como "192.168.0.1";
             * - IPv6 - O host é um endereço IP versão 6, como "2001: 0DB8: AC10: FE01 ::";
            */
            Console.WriteLine($"HostNameType: {uri.HostNameType}");

            // PathAndQuery: retorna a informação do caminho e da consulta como uma string.(Não existe uma propriedade Path).
            Console.WriteLine($"PathAndQuery: {uri.PathAndQuery}");

            // Segments: retorna uma matriz de strings contendo os "segmentos" (substrings) que formam o caminho absoluto do URI. O primeiro segmento é obtido através da análise do caminho absoluto do seu primeiro caractere até chegar a uma barra (/) ou ao final do caminho. Cada segmento adicional começa no primeiro caractere após o segmento anterior e termina com a próxima barra ou o final do caminho. (O caminho absoluto de URI contém tudo após o host e a porta e antes da consulta e do fragmento).
            foreach (string segment in uri.Segments)
            {
                Console.WriteLine(segment);
            }


            // LocalPath: obtém o caminho local. Ela é útil quando você tem uma URI que representa uma caminho de um arquivo. Exemplo logo após.
            Console.WriteLine($"LocalPath: { uri.LocalPath}");

            Uri filePath = new Uri("file://c:/windows/system32/vfprint.dll");
            Console.WriteLine($"\nExemplo de caminho de arquivo: {filePath.LocalPath}");

        }

        static void PropriedadesBooleanas()
        {
            Console.WriteLine($"\n=== Propriedades booleanas da URI: {uri} \n");

            // IsAbsoluteUri: essa propriedade é true se a URI representada pelo objeto for absoluta e false se for relativa.
            Console.WriteLine($"IsAbsoluteUri: {uri.IsAbsoluteUri}");

            // IsDefaultPort: essa propriedade é true se o número da porta não estiver presente, ou se estiver configurada para o número de porta padrão esperado pelo esquema URI. Quando um número de porta alternativo for especificado, o valor de retorno é false.
            Console.WriteLine($"IsDefaultPort: {uri.IsDefaultPort}");

            // IsFile: essa propriedade está definida como true para caminhos de arquivos e false para todos os outros esquemas URI.s
            Console.WriteLine($"IsFile: {uri.IsFile}");

            // IsLoopback: esta propriedade retorna true para URIs que são locais. Isso inclui URIs como "http:/ localhost" e "127.0.0.1".
            Console.WriteLine($"IsLoopback: {uri.IsLoopback}");

            // IsUnc: esta propriedade retorna true quando a Uri possui um caminho UNC (Universal Naming Convention. Ex: \\\\servername\\sharename\\directory\\).
            Console.WriteLine($"IsUnc: {uri.IsUnc}");
        }

        static void MakeRelativeUri()
        {
            // MakeRelativeUri(): determina a diferença entre duas instâncias URI.
            Console.WriteLine($"\n=== Testando método MakeRelativeUri()\n");

            Uri uri1 = new Uri("http://www.macoratti.net/c_uri1.htm");
            Uri uri2 = new Uri("http://www.macoratti.net/images/represa1.jpg");
            Console.WriteLine($"uri1 : {uri1}");
            Console.WriteLine($"uri2 : {uri2}");
            
            Console.WriteLine($"\nuri1.MakeRelativeUri(uri2) : {uri1.MakeRelativeUri(uri2)}");
            Console.WriteLine($"uri2.MakeRelativeUri(uri1) : {uri2.MakeRelativeUri(uri1)}");
        }

        static void GetLeftPart()
        {
            // GetLeftPart(): permite extrair partes de uma URI utilizando a enumeração UriPartial.
            Console.WriteLine($"\n=== Testando método GetLeftPart()\n");

            Console.WriteLine(uri.GetLeftPart(UriPartial.Scheme));
            Console.WriteLine(uri.GetLeftPart(UriPartial.Authority));
            Console.WriteLine(uri.GetLeftPart(UriPartial.Path));
            Console.WriteLine(uri.GetLeftPart(UriPartial.Query));
        }

        static void CheckHostName()
        {
            // CheckHostName(): método estático que determina se o nome do host especificado é um nome DNS válido. Este método retorna um valor da enumeração UriHostNameType que descreve o tipo de host detectado.
            Console.WriteLine($"\n=== Testando método CheckHostName()\n");

            Console.WriteLine($"www.macoratti.net: {Uri.CheckHostName("www.macoratti.net")}");
            Console.WriteLine($"192.168.0.1: {Uri.CheckHostName("192.168.0.1")}");
            Console.WriteLine($"2001:0DB8:AC10:FE01:: -> {Uri.CheckHostName("2001:0DB8:AC10:FE01::")}");
            Console.WriteLine($"!: {Uri.CheckHostName("!")}");
            Console.WriteLine($"localhost: {Uri.CheckHostName("localhost")}");
            Console.WriteLine($"127.0.0.1: {Uri.CheckHostName("127.0.0.1")}");            
        }

        static void CheckSchemeName()
        {
            // Determina se o nome do esquema especificado é válido. Retorna true se o nome do esquema não contém caracteres inválidos (por padrão, a validação é feita de acordo com a RFC 2396).
            Console.WriteLine($"\n=== Testando método CheckSchemeName()\n");

            Console.WriteLine($"http: " + Uri.CheckSchemeName("http"));
            Console.WriteLine($"invalido: " + Uri.CheckSchemeName("invalido"));
        }

        static void DigitosHexadecimais()
        {
            /* Existem limitações nos caracteres que podem ser usados ​​em URIs.
             * Quando necessário o uso, pode-se codificá-los usando número hexadecimal prefixado com um símbolo de porcentagem (%).
             * Para usar um e comercial (&), codifica-se como "%26". Exemplo: "?Query=teste%26demo".
             */
            Console.WriteLine($"\n=== Trabalhando com Números Hexadecimais\n");

            string codificacao;
            int valor = 0;
            char caractere;

            // HexEscape(): aceita um valor de caractere e retorna a string codificada.
            codificacao = Uri.HexEscape('&');

            /* HexUnescape(): requer dois parâmetros:
             * O primeiro é uma seqüência de caracteres que contém um caractere codificado hexadecimal para decodificar.
             * O segundo é um inteiro, passado por referência, que especifica o índice do símbolo de porcentagem que inicia a seção codificada. Ele retorna um caractere decodificado.
             */
            caractere = Uri.HexUnescape(codificacao, ref valor);

            Console.WriteLine("Codificando e decodificando caracteres:");
            Console.WriteLine($"Resultado => {caractere} = {codificacao}");


            // IsHexEnconding(): verifica se um ponto específico de uma cadeia representa um caractere codificado. Usa os mesmos parâmetros que HexDecode, exceto que a posição do índice é passada pelo valor. O método retorna true se o texto na posição dada for decodificável e false caso contrário.
            Console.WriteLine("\nVerificando Codificação: ");
            Console.WriteLine($"%26 => {Uri.IsHexEncoding("%26", 0)}");
            Console.WriteLine($"Valor => {Uri.IsHexEncoding("Valor", 0)}");

            Console.WriteLine("\nMétodos adicionais para trabalho com Hexadecimal: ");
            // IsHexDigit(): verifica se um caractere contém um dígito hexadecimal (0-9 ou A-F).
            Console.WriteLine($"FromHex('F') => " + Uri.FromHex('F'));
            // FromHex(): converte um único dígito hexadecimal, fornecido como um caractere, ao seu inteiro equivalente;
            Console.WriteLine($"Uri.IsHexDigit('F') => " + Uri.IsHexDigit('F'));
        }
    }
}
