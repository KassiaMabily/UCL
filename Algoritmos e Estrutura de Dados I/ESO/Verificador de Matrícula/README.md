Para melhorar a segurança do sistema de informação da UCL vamos criar um dígito verificador para a matrícula de cada aluno. Um dígito verificador é um (às vezes mais de um) dígito que é calculado em função dos dígitos do número principal. Por exemplo, o CPF é formado por 11 dígitos, os últimos 2 são dígitos verificadores que são calculados a partir dos 9 primeiros.

Faça um programa em C# que calcule um dígito verificador para a matrícula de um aluno. O cálculo deve ser realizado da seguinte forma:

- Em primeiro lugar deve-se calcular um somatório da seguinte forma: 1º dígito multiplicado por 2 + 2º dígito multiplicado por 3 + 3º dígito multiplicado por 4 + 4º dígito multiplicado por 3 + 5º dígito multiplicado por 2 + 6º dígito + 7º dígito + 8º dígito
Após o somatório deve-se obter o resto da divisão inteira do somatório por 10
- O programa deve solicitar ao usuário a entrada do número de matrícula um a um. 
- Ao fim da execução o programa deve imprimir a matrícula completa do aluno com o seu dígito verificador. Ex.: 34578123-1

Exemplo de cálculo: seja a matrícula do aluno igual a 34578123, então.
- Somatório = 3 x 2 + 4 x 3 + 5 x 4 + 7 x 3 + 8 x 2 +1+2+3 = 6 + 12 + 20 + 21 + 16 + 6 = 81
- Dígito = Resto da divisão de 81 por 10 que é igual a 1.

Assim, a matrícula com o dígito verificador seria 34578123-1.