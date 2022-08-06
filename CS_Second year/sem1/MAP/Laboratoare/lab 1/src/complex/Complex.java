package complex;

public class Complex {
    double re;
    double im;

    public Complex(double r , double i){
        re = r;
        im = i;
    }

    public void Args(){
        System.out.println("Partea reala a numarului este : " + this.re + " " + ",iar partea imaginara a numarului este :" + " " + this.im);
    }

    public Complex Adunare(Complex a){
        return new Complex(this.re + a.re , this.im + a.im);
    }

    public Complex Scadere(Complex a){
        return new Complex(this.re - a.re , this.im - a.im);
    }

    public Complex Inmultire(Complex a) {
        return new Complex(this.re * a.re - this.im * a.im, this.re * a.im + this.im * a.re);
    }

    public Complex Impartire(Complex a){
        Complex conj = a.Conjugat();
        Complex numerator = this.Inmultire(conj);
        Complex denominator = a.Inmultire(conj);
        return new Complex(numerator.re / denominator.re , numerator.im / denominator.re);
    }

    public Complex Conjugat(){
        return new Complex(this.re , -this.im);
    }



}
