document.addEventListener('DOMContentLoaded', function() {
    const transactionForm = document.getElementById('transaction-form');
    const transactionsList = document.getElementById('transactions-list');
    const totalIncomeElement = document.getElementById('total-income');
    const totalExpenseElement = document.getElementById('total-expense');
    const balanceElement = document.getElementById('balance');

    let transactions = [];

    transactionForm.addEventListener('submit', function(event) {
        event.preventDefault();

        const description = document.getElementById('description').value;
        const amount = parseFloat(document.getElementById('amount').value);
        const type = document.getElementById('type').value;

        const transaction = {
            description,
            amount,
            type
        };

        transactions.push(transaction);
        updateTransactionsList();
        updateSummary();

        transactionForm.reset();
    });

    function updateTransactionsList() {
        transactionsList.innerHTML = '';

        transactions.forEach((transaction, index) => {
            const transactionElement = document.createElement('li');
            transactionElement.textContent = `${transaction.description}: R$ ${transaction.amount.toFixed(2)} (${transaction.type === 'income' ? 'Receita' : 'Despesa'})`;
            transactionsList.appendChild(transactionElement);
        });
    }

    function updateSummary() {
        const totalIncome = transactions
            .filter(transaction => transaction.type === 'income')
            .reduce((sum, transaction) => sum + transaction.amount, 0);

        const totalExpense = transactions
            .filter(transaction => transaction.type === 'expense')
            .reduce((sum, transaction) => sum + transaction.amount, 0);

        const balance = totalIncome - totalExpense;

        totalIncomeElement.textContent = `R$ ${totalIncome.toFixed(2)}`;
        totalExpenseElement.textContent = `R$ ${totalExpense.toFixed(2)}`;
        balanceElement.textContent = `R$ ${balance.toFixed(2)}`;
    }
});
