package com.eletroland.appteem;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.ColorMatrix;
import android.graphics.ColorMatrixColorFilter;
import android.graphics.Paint;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.Drawable;
import android.support.v7.app.AppCompatActivity;
import android.app.Activity;
import android.app.ActionBar.LayoutParams;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageSwitcher;
import android.widget.ImageView;
import android.widget.SeekBar;
import android.widget.SeekBar.OnSeekBarChangeListener;
import android.widget.Toast;
import android.widget.ViewSwitcher.ViewFactory;

public class Saturation extends AppCompatActivity {
    Bitmap bitmap;
    private ImageSwitcher sw;
    private Button btnFogo;
    private Button btnRaio;
    private Button btnCirculo;

    private SeekBar satBar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_saturation);

        btnFogo = (Button)findViewById(R.id.btnFogo);
        btnRaio = (Button)findViewById(R.id.btnRaio);
        btnCirculo = (Button)findViewById(R.id.btnCircle);

        //Recebendo o parâmetro passado pela Tela Incial
        String nomeimagem = "";
        Bundle b = getIntent().getExtras();
        if(b != null) nomeimagem = b.getString("Imagem");

        sw = (ImageSwitcher)findViewById(R.id.imgSwitch);

        sw.setFactory(new ViewFactory() {
            @Override
            public View makeView() {
                ImageView myView = new ImageView(getApplicationContext());
                myView.setScaleType(ImageView.ScaleType.FIT_CENTER);
                myView.setLayoutParams(new
                        ImageSwitcher.LayoutParams(LayoutParams.WRAP_CONTENT,
                        LayoutParams.WRAP_CONTENT));
                return myView;
            }
        });

        satBar = (SeekBar) findViewById(R.id.seekSat);
        satBar.setOnSeekBarChangeListener(seekBarChangeListener);

        btnFogo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Toast.makeText(getApplicationContext(), "Fogo",
                        Toast.LENGTH_SHORT).show();
                sw.setImageResource(R.drawable.fire);
                bitmap = BitmapFactory.decodeResource(getResources(),
                        R.drawable.fire);
                satBar.setProgress(50);

            }
        });


        btnRaio.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Toast.makeText(getApplicationContext(), "Raio",
                        Toast.LENGTH_SHORT).show();
                sw.setImageResource(R.drawable.raio);
                bitmap = BitmapFactory.decodeResource(getResources(),
                        R.drawable.raio);
                satBar.setProgress(50);
            }
        });


        btnCirculo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Toast.makeText(getApplicationContext(), "Al",
                        Toast.LENGTH_SHORT).show();
                sw.setImageResource(R.drawable.circle);
                bitmap = BitmapFactory.decodeResource(getResources(),
                        R.drawable.circle);
                satBar.setProgress(50);
            }
        });

        switch (nomeimagem) {
            case "Fire":
                sw.setImageResource(R.drawable.fire);
                bitmap = BitmapFactory.decodeResource(getResources(), R.drawable.fire);
                break;
            case "Ball":
                sw.setImageResource(R.drawable.circle);
                bitmap = BitmapFactory.decodeResource(getResources(), R.drawable.circle);
                break;
            case  "Raio":
                sw.setImageResource(R.drawable.raio);
                bitmap = BitmapFactory.decodeResource(getResources(), R.drawable.raio);
                break;
            default:
                sw.setImageResource(R.drawable.anchieta);
                bitmap = BitmapFactory.decodeResource(getResources(), R.drawable.anchieta);
                break;
        }

        satBar.setProgress(50);


    }



    OnSeekBarChangeListener seekBarChangeListener = new OnSeekBarChangeListener() {

        @Override
        public void onProgressChanged(SeekBar seekBar, int progress,
                                      boolean fromUser) {
            // TODO Auto-generated method stub
        }

        @Override
        public void onStartTrackingTouch(SeekBar seekBar) {
            // TODO Auto-generated method stub
        }
        @Override
        public void onStopTrackingTouch(SeekBar seekBar) {
            MudarSaturação();
        }
    };

    private void MudarSaturação() {
        if (bitmap != null) {

            float valor_saturacao = (float) satBar.getProgress() / 50;

            Bitmap img = bitmap;

            int w = img.getWidth(); //Largura
            int h = img.getHeight();  //Altura

            Bitmap imagem = Bitmap.createBitmap(w, h, Bitmap.Config.ARGB_8888);
            Canvas canvas = new Canvas(imagem);
            Paint efeito = new Paint();
            ColorMatrix cor = new ColorMatrix();
            cor.setSaturation(valor_saturacao);
            ColorMatrixColorFilter filtro = new ColorMatrixColorFilter(cor);
            efeito.setColorFilter(filtro);
            canvas.drawBitmap(img, 0, 0, efeito);
            Drawable d = new BitmapDrawable(getResources(),imagem);

            sw.setImageDrawable(d);
        }
    }

    public void btnVoltarClick(View v) {
        GoTo(MainActivity.class);
    }

    public void GoTo(Class c) {
        Intent intent = new Intent(Saturation.this, c);
        startActivity(intent);
        finish();
    }



}
