package br.com.itb.teem.eletrolandia2;


import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

public class Tela1Inicial extends Activity implements OnClickListener {
	Button btnFaleConosco, btnSobreNos, btnTelaAvalie, btnBuscarProdutos;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.tela1_inicial);
        
        btnSobreNos = (Button) findViewById(R.id.btnSobreNos);
		btnSobreNos.setOnClickListener(this);

		btnFaleConosco = (Button) findViewById(R.id.btnFaleConosco);
		btnFaleConosco.setOnClickListener(this);

		btnTelaAvalie = (Button) findViewById(R.id.btnVoltarTA);
		btnTelaAvalie.setOnClickListener(this);

		btnBuscarProdutos = (Button) findViewById(R.id.btnBuscarProdutosTI);
		btnBuscarProdutos.setOnClickListener(this);
    }
	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.btnSobreNos:
			Intent t1 = new Intent(this, Tela3SobreNos.class);
			startActivity(t1);
			break;
		case R.id.btnFaleConosco:
			Intent t2 = new Intent(this, Tela4FaleConosco.class);
			startActivity(t2);
			break;
		case R.id.btnVoltarTA:
			Intent t3 = new Intent(this, Tela5AvalieApp.class);
			startActivity(t3);
			break;
		case R.id.btnBuscarProdutosTI:
			Intent t4 = new Intent(this, Tela2Produtos.class);
			startActivity(t4);
			break;
		}
	}
}
