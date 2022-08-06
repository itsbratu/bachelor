package complex;

import factory.Operation;

public abstract class ComplexExpression {
    private Operation op;
    private Complex[] args;

    public ComplexExpression(Operation op , Complex[] args) {
        this.op = op;
        this.args = args;
    }

    protected abstract Complex executeOneOperation(Complex a , Complex b);

    public Complex execute(){
        Complex executeResult = args[0];
        for(int i = 1 ; i < args.length ; ++i){
            executeResult = executeOneOperation(executeResult , args[i]);
        }
        return executeResult;
    }
}
