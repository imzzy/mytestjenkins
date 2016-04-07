package cn.leanpro.model;

import cn.leanpro.annotation.Column;

public class Browers {

	@Column(name="browser")
	private String browser;

	public String getBrowser() {
		return browser;
	}

	public void setBrowser(String browser) {
		this.browser = browser;
	}
	
	
}
