// Bir class'ın sadece bir amacı olmalı

using _1_SingleResponsibility;

ProductRepository productRepository = new ProductRepository();

ProductPresenter presenter = new ProductPresenter();

presenter.WriteToConsole(productRepository.GetProducts);