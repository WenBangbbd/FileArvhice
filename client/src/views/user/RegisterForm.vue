<template>
  <div id="container">
    <a-form :model="formState" :label-col="labelCol" :layout="formState.layout">
      <a-form-item label="注册">
        <a-input v-model:value="value" placeholder="Email" />
      </a-form-item>
      <a-form-item>
        <a-input placeholder="密码" v-model:value="userName">
          <template #prefix>
            <LockOutlined />
          </template>
          <template #suffix>
            <EyeInvisibleOutlined />
          </template>
        </a-input>
      </a-form-item>
      <a-form-item>
        <a-input placeholder="密码确认" v-model:value="userName">
          <template #prefix>
            <LockOutlined />
          </template>
          <template #suffix>
            <EyeInvisibleOutlined />
          </template>
        </a-input>
      </a-form-item>
      <a-form-item>
        <div>
          <a-input v-model:value="value2">
            <template #addonBefore>
              <a-select v-model:value="value1" style="width: 90px">
                <a-select-option value="+86">+86</a-select-option>
                <a-select-option value="+87">+87</a-select-option>
              </a-select>
            </template>
          </a-input>
        </div>
      </a-form-item>
      <a-form-item>
       <div>
         <a-input class="vertifycode" placeholder="Password" v-model:value="userName">
          <template #prefix>
            <MailOutlined />
          </template>
        </a-input>
        <a-button class="vertify" type="primary">发送</a-button>
       </div>
      </a-form-item>
      <a-form-item>
        <a-button class="register" type="primary">注册</a-button>
        <router-link class="haveaccount" :to="{name:'login'}">已有账号</router-link>
      </a-form-item>
    </a-form>
  </div>
</template>
<script>
import { defineComponent, reactive, ref, toRaw } from "vue";
import { LockOutlined, EyeInvisibleOutlined,MailOutlined } from "@ant-design/icons-vue";
export default defineComponent({
  components: {
    LockOutlined,
    EyeInvisibleOutlined,
    MailOutlined
  },
  setup() {
    const formState = reactive({
      name: "",
      region: undefined,
      date1: undefined,
      delivery: false,
      type: [],
      resource: "",
      desc: "",
      layout: "vertical",
    });
    const onSubmit = () => {
      console.log("submit!", toRaw(formState));
    };

    const value1 = ref("+86");
    return {
      value1,
      labelCol: {
        span: 4,
      },
      wrapperCol: {
        span: 14,
      },
      formState,
      onSubmit,
    };
  },
});
</script>

<style lang="less" scoped>
#container {
  width: 800px;
  margin: 20px auto;
  .ant-form {
    width: 400px;
    margin: 0 auto;
  }
  .vertifycode{
    width: 320px;
  }
  .vertify{
    float: right;
  }
  .register{
    width: 320px;
  }
  .haveaccount{
    float: right;
    padding-top: 5px;
  }
}
</style>