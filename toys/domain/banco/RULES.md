1️⃣ Base das Contas
Todas as contas bancárias devem ter:

Titular (Nome do cliente)
Saldo (Armazena o valor disponível)
Método de Depósito (Adicionar saldo sem restrições)
Método de Saque (Regras variam conforme o tipo de conta)
Método para Exibir Saldo (Para visualizar o saldo atual)
Esses elementos formam a classe base chamada Conta.

2️⃣ Tipos de Contas e suas Regras

1. Conta Corrente 🏦
   Perfil: Conta tradicional para transações do dia a dia.

✅ Depósito: Qualquer valor positivo pode ser depositado.
✅ Saque: Permitido apenas se houver saldo suficiente.
✅ Tarifas: Sem tarifas sobre saque, mas pode ser aplicado um custo fixo mensal.
✅ Cheque Especial: Se ativado, permite saldo negativo até um limite determinado.


2. Conta Poupança 💰
   Perfil: Conta voltada para economia de longo prazo.

✅ Depósito: Permitido normalmente.
✅ Saque: Aplicada uma taxa de 2% sobre o valor sacado.
✅ Rendimento: O saldo rende automaticamente a uma taxa de 0,5% ao mês.
❌ Sem cheque especial.


3. Conta Salário 💼
   Perfil: Conta para recebimento de salário, sem muitas funcionalidades.

✅ Depósito: Somente a empresa empregadora pode depositar.
✅ Saque: Permitido sem taxas.
✅ Transferência: Apenas para uma conta do mesmo titular em outro banco.
❌ Sem cartão de crédito, cheque especial ou rendimento.


4. Conta Digital 📱
   Perfil: Conta moderna, sem agência física, com operações via aplicativo.

✅ Depósito: Livre, via Pix, TED ou boleto gerado.
✅ Saque: Sem taxas via Pix, mas caixa eletrônico cobra R$ 6,90 por saque.
✅ Transferências: Gratuitas via Pix; TED/DOC podem ter limites diários.
✅ Benefícios: Cashback em compras no cartão.
❌ Sem cheque especial (apenas crédito via análise).


5. Conta Premium (Investimentos) 💎
   Perfil: Conta exclusiva para clientes de alta renda, com vantagens.

✅ Depósito: Livre.
✅ Saque: Sem taxas para grandes valores.
✅ Rendimento: Permite investimento automático no saldo livre.
✅ Crédito: Limites diferenciados.
✅ Benefícios: Taxas reduzidas em transferências e atendimento prioritário.


# FLUXO
- Cria um dos tipos
- Informa conta base
- Pode realizar as operações
- Deve mostrar logs
  - Se chegou, quando


- Cada classe cuida integramente de lidar com o tipo.