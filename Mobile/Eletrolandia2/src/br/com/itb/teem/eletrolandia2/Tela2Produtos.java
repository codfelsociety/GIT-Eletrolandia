package br.com.itb.teem.eletrolandia2;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;

public class Tela2Produtos extends Activity implements OnClickListener {
	Button btnProdutos, btnVoltar;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.tela2_produtos);

		btnProdutos = (Button) findViewById(R.id.btnMostrar);
		btnProdutos.setOnClickListener(this);

		btnVoltar = (Button) findViewById(R.id.btnVoltarTelaProdutos);
		btnProdutos.setOnClickListener(this);
	}

	private static final String[] opçoes = { "Celulares", "Notebooks",
			"Tablets", "Computadores", "Acessórios" };
	ArrayAdapter<String> aOpcoes;
	Spinner spnopcoes;
	Button btnMostrar;

	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.btnMostrar:
			Intent t1 = new Intent(this, Tela1Inicial.class);
			startActivity(t1);
			break;
		case R.id.btnVoltarTelaProdutos:
			Intent t2 = new Intent(this, Tela1Inicial.class);
			startActivity(t2);
			break;

		}

	}
}
